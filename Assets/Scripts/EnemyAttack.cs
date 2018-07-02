using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


    public float enemyDamage=1;//default


    Animator anim;

    /// <summary>
    /// Returns true if any animation is being played by the animator
    /// </summary>
    /// <returns></returns>
    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length > anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    bool AnimatorisPlayingAnimation(string animName)
    {
        return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }


    IEnumerator attackThenVanish()
    {
        anim.SetTrigger("isAttacking");

        while(AnimatorisPlayingAnimation("Attack"))
        {
            yield return new WaitForSeconds(1f);
        }
        //after this animation is done...
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //Enemy touched player, damage it
            Debug.Log(gameObject.name + " touched player!");
            PlayerStats.instance.DecreaseHP(enemyDamage);

            //update UI
            UIValuesTracker.instance.UpdateHP();

            StartCoroutine(attackThenVanish());
        }
    }


	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
