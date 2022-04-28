using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman_Controller : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;




    private static readonly string ANIMATOR_STATE = "Estado";
    private static readonly int ANIMATOR_IDLE = 0;
    private static readonly int ANIMATOR_RUN = 1;
    private static readonly int ANIMATOR_JUMP = 2;
    private static readonly int ANIMATOR_SHOT = 3;

    private static readonly int Right = 1;
    private static readonly int Left = -1;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector3(0, _rb.velocity.y);
        if(_rb.velocity == new Vector2(0, 0))
        {
            ChangeAnimation(ANIMATOR_IDLE);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazarse(Right);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(Left);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            ChangeAnimation(ANIMATOR_JUMP);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar_1();
            ChangeAnimation(ANIMATOR_SHOT);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Disparar_2();
            ChangeAnimation(ANIMATOR_SHOT);
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            Disparar_3();
            ChangeAnimation(ANIMATOR_SHOT);
        }
    }
    private void Disparar_1()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;
        var bulletGo = Instantiate(Bullet1, new Vector2(x, y), Quaternion.identity) as GameObject;
        var controller = bulletGo.GetComponent<Bullet1>();

        if (_sr.flipX)
        {
            controller.Velocity = controller.Velocity * -1;
        }
    }
    private void Disparar_2()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;
        var bulletGo = Instantiate(Bullet2, new Vector2(x, y), Quaternion.identity) as GameObject;
        var controller = bulletGo.GetComponent<Bullet2>();

        if (_sr.flipX)
        {
            controller.Velocity = controller.Velocity * -1;
        }
    }
    private void Disparar_3()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;
        var bulletGo = Instantiate(Bullet3, new Vector2(x, y), Quaternion.identity) as GameObject;
        var controller = bulletGo.GetComponent<Bullet3>();

        if (_sr.flipX)
        {
            controller.Velocity = controller.Velocity * -1;
        }
    }
    private void Desplazarse(int position)
    {
        _rb.velocity = new Vector2(Velocity * position, _rb.velocity.y);
        _sr.flipX = position == Left;
        ChangeAnimation(ANIMATOR_RUN);
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
}
