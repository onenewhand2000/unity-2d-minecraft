using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    public class WaitForCoreStart : CustomYieldInstruction
    {
        public override bool keepWaiting
        {
            get
            {
                return !Core.IsStarted;
            }
        }
    }
}
