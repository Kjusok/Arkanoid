using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocks : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteOfBlock;
    [SerializeField] private Text _score; 
    [SerializeField] private int _healthOfBlock;
    //public Ball BallIsActiv;
    [SerializeField] private int _points;

    public int _numberOfHits;
    // Start is called before the first frame update
    void Start()
    {
        //_score = GetComponent<Text>();
        

        _numberOfHits = 0;
        _spriteOfBlock = GetComponent<SpriteRenderer>();
       // _colorOfBlocks = GetComponent<Color>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_healthOfBlock == 1)
        {
            Color newColor = new Color(1,1,1);
            _spriteOfBlock.color = newColor;
            
        }
        if (_healthOfBlock == 2)
        {
            Color newColor = new Color(0.97f, 1, 0);
            _spriteOfBlock.color = newColor;

        }
        if (_healthOfBlock == 3)
        {
            Color newColor = new Color(1,0.5f,0);
            _spriteOfBlock.color = newColor;
        }

    }
    private void OnCollisionEnter2D(Collision2D contact)
    {
        if (contact.gameObject.tag == "Ball" )
        {
            _numberOfHits++;
            _healthOfBlock--;

            if ( _healthOfBlock==0)
            {
                _score.text += "100";
                Destroy(this.gameObject);
            }
        }
    }
}