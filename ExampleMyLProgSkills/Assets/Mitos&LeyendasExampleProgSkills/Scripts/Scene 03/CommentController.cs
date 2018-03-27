
using UnityEngine;
using UnityEngine.UI;

public class CommentController : MonoBehaviour {
    Comment comment;
    Text txtTNameEmail,txtBody;

    public void setCommentProperties(Comment _comment)
    {
        txtTNameEmail = transform.GetChild(0).GetComponent<Text>();
        txtBody = transform.GetChild(1).GetComponent<Text>();

        setComment(_comment);
    }

    public void setComment(Comment _comment)
    {
        comment = _comment;
        txtTNameEmail.text = comment.name + " - " + comment.email;
        txtBody.text = comment.body;
    }
}
