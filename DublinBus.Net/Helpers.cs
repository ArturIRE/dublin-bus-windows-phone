using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;

namespace DublinBus.Net
{
    public static class Helpers
    {
        public static void ThrowIfNull(this object obj, string parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static IEnumerable<string> ExtractTimes(string htmlSwampedTimes)
        {
            var stripped = htmlSwampedTimes.Replace("<html><head><title>api</title></head><body>", string.Empty);
            stripped = stripped.Replace("</body></html>", string.Empty);

            foreach (var waitTime in stripped.Split(new[] { "<br/>" }, StringSplitOptions.None))
            {
                yield return waitTime;
            }
        }
    }
}
