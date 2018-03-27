using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIAiClassModel  {

    public class Parameters
    {
        public string number { get; set; }
        public string butter { get; set; }
        public string pass { get; set; }
        public string even { get; set; }
        public string odd { get; set; }
        public string given_name { get; set; }
        public string geo_city { get; set; }
    }

    public class Metadata
    {
        public string intentName { get; set; }
        public string intentId { get; set; }
    }

    public class Fulfillment
    {
        public string speech { get; set; }
    }

    public class Result
    {
        public string action { get; set; }
        public Parameters parameters { get; set; }
        public List<object> contexts { get; set; }
        public Metadata metadata { get; set; }
        public string resolvedQuery { get; set; }
        public Fulfillment fulfillment { get; set; }
        public string source { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string errorType { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public Result result { get; set; }
        public Status status { get; set; }
        public bool IsError { get; set; }
    }
}
