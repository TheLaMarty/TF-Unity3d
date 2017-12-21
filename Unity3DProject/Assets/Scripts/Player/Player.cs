using UnityEngine;

[RequireComponent(typeof(WeaponController))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : LivingEntity
{
    Camera mainCamera;
    PlayerMovement movementController;
    public float moveSpeed = 5;
    static Player instance;
    WeaponController weaponController;

    Player() { }

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }
    }

    protected override void Start()
    {
        base.Start();
        movementController = GetComponent<PlayerMovement>();
        weaponController = GetComponent<WeaponController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        movementController.Move(moveVelocity);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (ground.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.green);
            movementController.LookAt(point);
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponController.Shoot();
        }

    }
}
