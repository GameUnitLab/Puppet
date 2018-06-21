﻿namespace Puppet.Conditions
{
    internal class Active : Condition
    {
        public override bool Invoke<T>(T gameObject)
        {
            _curentGameObject = gameObject;
            return gameObject.IsActive();
        }

        protected override string DescribeExpected()
        {
            return $"Enabled {true}";
        }

        protected override string DescribeActual()
        {
            return $"Enabled {false}";
        }
    }

    public static partial class Be
    {
        public static Condition Enabled => new Active();
    }
}