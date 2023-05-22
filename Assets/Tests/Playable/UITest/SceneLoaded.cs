using Tests.Playable.UITest.Conditions;
using UnityEngine.SceneManagement;

namespace Tests.Playable.UITest
{
    internal class SceneLoaded : Condition<string>
    {
        public SceneLoaded(string param) : base(param)
        {
        }

        public override bool Satisfied()
        {
            return SceneManager.GetActiveScene().name == Param;
        }
    }
}