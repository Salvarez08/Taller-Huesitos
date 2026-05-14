using UnityEngine;

public class SpriteCharacterController : MonoBehaviour
{
    [Header("Sprite Renderer")]
    [SerializeField]
    private SpriteRenderer _mainRender;
    [SerializeField]
    private SpriteRenderer _whiteRender;
    [SerializeField]
    private SpriteRenderer _eyelidsRender;
    [SerializeField]
    private SpriteRenderer _pupilRender;
    [SerializeField]
    private SpriteRenderer _tearsRender;
    [SerializeField]
    private SpriteRenderer _cheeksRender;
    [SerializeField]
    private SpriteRenderer _eyebrowsRender;
    [SerializeField]
    private SpriteRenderer _graphicSymbolsRender;
    [SerializeField]
    private SpriteRenderer _hairRender;
    [SerializeField]
    private SpriteRenderer _mouthRender;

    [Header("Sprite")]
    [SerializeField]
    private Sprite _mainSprite;
    [SerializeField]
    private Sprite _whiteSprite;
    [SerializeField]
    private Sprite _hairSprite;
 

    [Header("Array SpriteRenderer")]
    [SerializeField]
    private SpriteRenderer[] _spriteRenderers;

    [Header("Array Sprites")]
    [SerializeField]
    private Sprite[] _tearSprites;
    [SerializeField]
    private Sprite[] _mouthSprites;
    [SerializeField]
    private Sprite[] _graphicSymbolsSprites;
    [SerializeField]
    private Sprite[] _eyelidSprites;
    [SerializeField]
    private Sprite[] _pupilSprites;
    [SerializeField]
    private Sprite[] _eyebrowSprites;
    [SerializeField]
    private Sprite[] _cheekSprites;



    private void Start()
    {
        _mainRender.color = Color.red;
    }
}
