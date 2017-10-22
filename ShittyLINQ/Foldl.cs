﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShittyLINQ
{
    public static partial class Extensions
    {
        /// <summary>
        /// Fold your shit to the left.
        /// </summary>
        /// <typeparam name="T">The type of shit that's 'bout to get folded.</typeparam>
        /// <typeparam name="U">The folded shit.</typeparam>
        /// <param name="self">A bunch of shit to fold.</param>
        /// <param name="memo">A seed to start your shit with. A kernel, if you will.</param>
        /// <param name="accumulator">Describe how you want to fold this shit up.</param>
        /// <returns>The folded shit.</returns>
        public static U Foldl<T, U>(this IEnumerable<T> self, U memo, Func<U, T, U> accumulator)
        {
            if (self == null || memo == null || accumulator == null) throw new ArgumentNullException();
            
            var iterator = self.GetEnumerator();
            if(!iterator.MoveNext())
            {
                return memo;
            }
            U output = accumulator(memo, iterator.Current);

            while (iterator.MoveNext())
            {
                output = accumulator(output, iterator.Current);
            }
            return output;
        }
    }
}
