using System.Collections;
using Tests.Playable.UITest;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tests.Playable.Utils
{
    public class GameplayUtils : UiTest
    {
        public static IEnumerator Load()
        {
            SceneManager.LoadScene("Splash");
            yield return new WaitForSeconds(2);
        }

        protected override void SubstituteResources()
        {
            
        }
    }
}