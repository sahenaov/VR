using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private float force = 20.0f;
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private Rigidbody m_Rigidbody;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private GameObject bullet;

    [ContextMenu("Bullet Shot")]
    public void BulletShot()
    {
        m_Rigidbody.isKinematic = false;
        m_Rigidbody.AddForce((transform.up + transform.right) * force);
        
        StartCoroutine("ActiveGravity");
    }

    IEnumerator ActiveGravity()
    {
        yield return new WaitForSeconds(waitTime);

        boxCollider.isTrigger = true;
        m_Rigidbody.useGravity = true;
        
        Destroy(bullet, 2.0f);
        
        CreateBullet();
    }

    [ContextMenu("Create Bullet")]
    public void CreateBullet()
    {
        bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, this.transform);
        
        bullet.GetComponent<Transform>().position = bulletTransform.position;
        bullet.GetComponent<Transform>().eulerAngles = bulletTransform.eulerAngles;

        boxCollider = bullet.GetComponent<BoxCollider>();
        m_Rigidbody = bullet.GetComponent<Rigidbody>();
    }
}
