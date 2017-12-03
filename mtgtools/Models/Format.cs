﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models
{
    /// <summary>
    /// A Magic The Gathering © format.
    /// </summary>
    public class Format
    {
        private static readonly Format _Commander;
        public static Format Commander { get { return _Commander; } }
        private static readonly Format _Legacy;
        public static Format Legacy { get { return _Legacy; } }
        private static readonly Format _Modern;
        public static Format Modern { get { return _Modern; } }
        private static readonly Format _Standard;
        public static Format Standard { get { return _Standard; } }

        static Format()
        {
            _Commander = new Format();
            _Legacy = new Format();
            _Modern = new Format();
            _Standard = new Format();
        }
    }
}