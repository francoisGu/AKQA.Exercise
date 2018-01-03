using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Exercise.AppLogic.Services
{
    public interface INumToWords
    {
        /// <summary>
        ///     This service will convert number into words
        /// </summary>
        /// <param name="number">number in double</param>
        /// <returns>a string of number of words</returns>
        string ConvertNumToWords(double number);
    }
}
