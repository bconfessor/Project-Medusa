using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


    public float enemyDamage=1;//default

    public bool isAttacking = false;

    public AudioClip attackSFX;

    AudioSource audioS;

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
        Debug.Log("Setting attack to true");
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("isAttacking", false);
        while (AnimatorisPlayingAnimation("Attack"))
        {
            yield return new WaitForSeconds(.2f);
        }
        //after this animation is done...

        //attack player
        PlayerStats.instance.DecreaseHP(enemyDamage);
        //play attack sound
        float currentVol = audioS.volume;
        audioS.volume = 0.8f;
        audioS.PlayOneShot(attackSFX);

        //update UI
        UIValuesTracker.instance.UpdateHP();

        audioS.volume = currentVol;
        //then vanish
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //Enemy touched player, damage it
            Debug.Log(gameObject.name + " touched player!");
            

            StartCoroutine(attackThenVanish());
        }
    }


	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
