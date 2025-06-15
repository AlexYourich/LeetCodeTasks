namespace LeetCodeTasks;

public class Solution {
    
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int LengthOfLongestSubstring(string s)
    {

        if (string.IsNullOrEmpty(s)) return 0;
        
        var maxLen=1;

        var foundChars = new HashSet<char>();
        
        var maxPosition = s.Length - 1;
        for (var i1=0; i1<maxPosition; i1++)
        {
            if ((maxPosition - i1) < maxLen) break;
            
            foundChars.Clear();
            
            for (var i2 = i1 + 1; i2 < s.Length; i2++)
            {
                if (!foundChars.Add(s[i2]))
                {
                    var len = foundChars.Count;
                    if (len > maxLen) maxLen = len;
                    break;
                }
            }
        }

        return maxLen;
    }
}