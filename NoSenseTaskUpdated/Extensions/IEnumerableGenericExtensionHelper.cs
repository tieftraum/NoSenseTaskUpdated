using System;
using System.Collections.Generic;
using System.Linq;

namespace NoSenseTask.Extensions
{
    public static class IEnumerableGenericExtensionHelper
    {
        public static T ThisDoesntMakeAnySense<T>(this IEnumerable<T> arg,
            Predicate<T> predicateDel,
            Func<T[], T> funcDel)
        {
            if (arg == null || arg.Count() == 0) throw new ArgumentNullException($"Specified array is null");
            if (predicateDel == null) throw new ArgumentNullException("Predicate is null");
            if (funcDel == null) throw new ArgumentNullException("Delegate is null");

            foreach (var item in arg)
            {
                if (predicateDel(item))
                {
                    //წინააღმდეგ შემთხვევაში, აბრუნებს ჯენერიკ ტიპის შესაბამის საწყის (ნაგულისხმევ, დეფაულტ) მნიშვნელობას.

                    //ამ დეფაულტ მნიშვნელობაში თუ იგულისხმება ის ელემენტი რომელმაც დააკმაყოფილა პრედიკატი მაშინ ზუსტად ეს წერია აქ და თუ უშუალოდ
                    //Generic (ამ შემთხვევაში int) ტიპის დეფაულტ მნიშვნელობა იგულისხმება მაშინ //return default(T);
                    //ეს მომენტი ცოტა გაუგებარივით იყო ჩემთვის და მაგიტომ ჩავთვალე კომენტარის დატოვება საჭირო. 
                    return item;
                }
            }
            return funcDel(arg.ToArray());
        }
    }
}
