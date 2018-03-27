using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ControllerScene03 : MonoBehaviour {
    public string googleKey = "AIzaSyCzV-36S8o49pnmdMLuvckkG4fNkFrGslI";
    public GoogleMap _googleMap;
    public Text _txtAddress;
    public GameObject goBackToPosts;
    public RectTransform panelOfPost;
    public RectTransform panelOfComments;
    public Button btnPostPrefab;
    public RectTransform commentPrefab;

    List<Post> ListPost = new List<Post>();
    PostController[] listPostControllers;

    List<Comment> ListComments = new List<Comment>();
    CommentController[] listCommentsControllers;

    int countOfPostPerLocation = 100;
    string addressToSearch;
    string addressString;
    double lat = 0;
    double lng = 0;
    
    public void searchForAddress()
    {
        searchForAdress();
    }
    
    public void showPosts()
    {
        goBackToPosts.SetActive(false);
        panelOfComments.parent.parent.gameObject.SetActive(false);
        panelOfPost.parent.parent.gameObject.SetActive(true);
    }

    public void showComments(Comment[] _comments)
    {
        goBackToPosts.SetActive(true);

        panelOfComments.parent.parent.gameObject.SetActive(true);
        float heightPost = commentPrefab.GetComponent<RectTransform>().rect.height;
        float widthPost = commentPrefab.GetComponent<RectTransform>().rect.width;
        float XPanelPost = panelOfComments.rect.x;
        float positionByI = 0;
        int count = 0;

        foreach (var resultComment in _comments)
        {
            positionByI = count * heightPost;
            if (listCommentsControllers.Length > count)
            {
                if (listCommentsControllers[count] == null)
                {
                    CommentController _comment = Instantiate(commentPrefab, Vector3.zero, Quaternion.identity, panelOfComments).GetComponent<CommentController>();
                    _comment.GetComponent<RectTransform>().anchoredPosition = new Vector2(panelOfComments.anchoredPosition.x + widthPost / 2,
                                                                                           panelOfComments.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y
                                                                                           - positionByI);
                    _comment.setCommentProperties(resultComment);
                    listCommentsControllers[count] = _comment;
                }
                else
                {
                    listCommentsControllers[count].setComment(resultComment);
                }
            }
            count++;
        }
        panelOfPost.parent.parent.gameObject.SetActive(false);

        panelOfComments.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, positionByI);
    }

    IEnumerator GetPostsAndComments()
    {
        yield return StartCoroutine(getLatLonByAdress(_txtAddress.text));
        yield return StartCoroutine(getJsonComment("https://jsonplaceholder.typicode.com/comments"));
        yield return StartCoroutine(getJsonPost("https://jsonplaceholder.typicode.com/posts"));
        createPostsAndComments();
    }

    IEnumerator getJsonPost(string httpsString) 
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(httpsString);
        yield return webRequest.SendWebRequest();

        if (!webRequest.isNetworkError)
        {
            Debug.Log(webRequest.downloadHandler.text);
            ListPost = JsonConvert.DeserializeObject<List<Post>>(webRequest.downloadHandler.text);
            listPostControllers = new PostController[ListPost.Count];
        }
        else
        {
            Debug.Log(webRequest.error);
        }
    }

    IEnumerator getJsonComment(string httpsString)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(httpsString);
        yield return webRequest.SendWebRequest();

        if (!webRequest.isNetworkError)
        {
            Debug.Log(webRequest.downloadHandler.text);
            ListComments = JsonConvert.DeserializeObject<List<Comment>>(webRequest.downloadHandler.text);
            listCommentsControllers = new CommentController[ListComments.Count];
        }
        else
        {
            Debug.Log(webRequest.error);
        }
    }

    public void createPostsAndComments()
    {
        float heightPost = btnPostPrefab.GetComponent<RectTransform>().rect.height;
        
        float widthPost = btnPostPrefab.GetComponent<RectTransform>().rect.width;
        float XPanelPost = panelOfPost.rect.x;
        float positionByI = 0;
        int count = 0;

        panelOfComments.parent.parent.gameObject.SetActive(false);

        foreach (var resulPost in ListPost)
        {
            positionByI = count * heightPost;
            if (listPostControllers.Length > count)
            {
                if (listPostControllers[count] == null)
                {
                    PostController btnPost = Instantiate(btnPostPrefab, Vector3.zero, Quaternion.identity, panelOfPost).GetComponent<PostController>();
                    btnPost.GetComponent<RectTransform>().anchoredPosition = new Vector2(panelOfPost.anchoredPosition.x + widthPost / 2,
                                                                                           panelOfPost.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y
                                                                                           - positionByI);
                    btnPost.listComments = ListComments.FindAll(delegate (Comment cmt)
                        {
                            return cmt.postId == resulPost.id;
                        }
                    ).ToArray();
                    btnPost.setPostProperties(resulPost);
                    listPostControllers[count] = btnPost;
                }
                else
                {
                    listPostControllers[count].setPost(resulPost);
                }
            }
            count++;
        }
       
        panelOfPost.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, positionByI);
    }
    
    void searchForAdress()
    {
        StartCoroutine(GetPostsAndComments());
    }

    IEnumerator getLatLonByAdress(string addressToSearch)
    {
        string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&oe=utf-8&key=" + googleKey, 
            Uri.EscapeDataString(addressToSearch));
        //WWW www = new WWW("https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&oe=utf-8&key=" + googleKey);
        WWW www = new WWW(requestUri);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
            GoogleAPIDefinition.RootObject rootObjectGoogleGeo = JsonConvert.DeserializeObject<GoogleAPIDefinition.RootObject>(www.text);
           
            foreach (var resultObject in rootObjectGoogleGeo.results)
            {
                var geometry = resultObject.geometry;
                var location = geometry.location;
                addressString = resultObject.formatted_address;
                lat = location.lat;
                lng = location.lng;
                Debug.Log("Object: " + lat + lng + location);

            }
            _googleMap.PutMarker(addressString, lat, lng);
            _googleMap.centerLocation.latitude = lat;
            _googleMap.centerLocation.longitude = lng;
            _googleMap.Refresh();
        }
    }
    
}
