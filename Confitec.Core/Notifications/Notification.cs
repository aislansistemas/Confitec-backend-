﻿namespace Confitec.Core.Notifications
{
    public class Notification
    {
        public Notification()
        {

        }

        public Notification(string value)
        {
            Value = value;
        }

        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
