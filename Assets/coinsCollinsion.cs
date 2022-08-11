using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsCollinsion : MonoBehaviour
{
    public float coinLiveTime = 5.0f;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Coin"){
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Animator>().SetBool("rotate", true);
            StartCoroutine(removeCoin(other.transform.parent.gameObject));
        }
    }

    IEnumerator removeCoin(GameObject coin) {
        yield return new WaitForSeconds(coinLiveTime);
        Destroy(coin);
    }
}
