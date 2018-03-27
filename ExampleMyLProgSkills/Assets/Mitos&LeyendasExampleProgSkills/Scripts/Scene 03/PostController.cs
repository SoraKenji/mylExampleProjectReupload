using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostController : MonoBehaviour {
    Post post;
    Text txtTitle, txtBody;
    Image iconImage;
    public Comment[] listComments;

    public void setPostProperties(Post _post)
    {
        txtTitle = transform.GetChild(0).GetComponent<Text>();
        txtBody = transform.GetChild(1).GetComponent<Text>();
        iconImage = transform.GetChild(2).GetChild(0).GetComponent<Image>();
        setPost(_post);
    }

    public void setPost(Post _post)
    {
        post = _post;
        txtTitle.text = post.title;
        txtBody.text = post.body;
    }
    
    public void touchPost()
    {
        if (listComments!=null)
        {
            GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<ControllerScene03>().showComments(listComments);
        }
    }
}
