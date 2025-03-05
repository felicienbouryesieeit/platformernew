using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallreaction : basescript
{




protected bool iscorrectground(Collider2D collision) {
        projectilescrpar otherprojectile= collision.gameObject.GetComponent<projectilescrpar>();
        //characterscr othercharacter = collision.gameObject.GetComponent<characterscr>();

        
        return (otherprojectile == null); // && othercharacter == null;
    }
    
}
