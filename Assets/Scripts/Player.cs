using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player info")]
    public float movespeed = 12f;
    public float jumpforce = 12f;
    public int facinngdir { get; private set; } = 1;
    private bool facingright = true;

    [Header("Collision info")]
    [SerializeField] Transform groundcheck;
    [SerializeField] float groundcheckdistance;
    [SerializeField] LayerMask groundlayer;
    [SerializeField] Transform wallcheck;
    [SerializeField] float wallcheckdistance;

    [Header("Dash info")]
    [SerializeField] public float dashspeed;
    [SerializeField] public float dashdurtation;
    [SerializeField] float dashcooldown;
    [SerializeField] float dashcooldowntimer;
    public PllayerStateMachine PllayerStateMachine { get; private set; }
    public Playeridle Playeridle { get; private set; }
    public Playermove Playermove { get; private set; }
    public PLayerJumpState pLayerJumpState { get; private set; }
    public PlayerAirState playerAirState { get; private set; }
    public PLayerDashState pLayerDashState { get; private set; }
    public PlayerWallSlideStatw playerWallSlideStatw { get; private set; }
    public PlayerWallJUmpstate playerWallJUmpstate { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody2D rigidbody2D { get; private set; }

    private void Awake()
    {
        PllayerStateMachine = new PllayerStateMachine();
        Playeridle = new Playeridle(PllayerStateMachine, this, "idle");
        Playermove = new Playermove(PllayerStateMachine, this, "move");
        pLayerJumpState = new PLayerJumpState(PllayerStateMachine, this, "Jump");
        playerAirState = new PlayerAirState(PllayerStateMachine, this, "Jump");
        pLayerDashState = new PLayerDashState(PllayerStateMachine, this, "Dash");
        playerWallSlideStatw = new PlayerWallSlideStatw(PllayerStateMachine, this, "WallSlide");
        playerWallJUmpstate = new PlayerWallJUmpstate(PllayerStateMachine, this, "Jump");
    }
    private void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        PllayerStateMachine.Initiallize(Playeridle);

    }
    private void Update()
    {
        PllayerStateMachine.Currentstate.Update();
        Dash();
    }
    public bool iusgrounded() => Physics2D.Raycast(groundcheck.position, Vector2.down, groundcheckdistance, groundlayer);
    public bool iswall() => Physics2D.Raycast(wallcheck.position, Vector2.right * facinngdir, wallcheckdistance, groundlayer);
    public void Setvelocity(float xvelocity, float yvelocity)
    {
        rigidbody2D.linearVelocity = new Vector2(xvelocity * movespeed, yvelocity);
        flipcontroller(xvelocity);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundcheck.position, new Vector3(groundcheck.position.x, groundcheck.position.y - groundcheckdistance));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(wallcheck.position, new Vector3(wallcheck.position.x + wallcheckdistance, wallcheck.position.y));

    }
    public void flipcontroller(float xvelocity)
    {
        if (xvelocity > 0 && !facingright)
        {
            flip();
        }
        else if (xvelocity < 0 && facingright)
        {
            flip();
        }
    }
    private void flip()
    {
        facinngdir *= -1;
        facingright = !facingright;
        transform.Rotate(0, 180, 0);
    }
    private void Dash()
    {
        dashcooldowntimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) &&dashcooldowntimer<0)
        {
            dashcooldowntimer = dashcooldown;
            PllayerStateMachine.Changestate(pLayerDashState);
        }
    }
}
