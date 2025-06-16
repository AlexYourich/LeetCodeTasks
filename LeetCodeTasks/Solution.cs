namespace LeetCodeTasks;

public class Solution {
    
    /// <summary>
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/description/
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {

        var len = nums1.Length + nums2.Length;

        
        switch (len)
        {
            case 0:
                return 0;
            case 1:
                return nums1.Length == 0 ? nums2[0] : nums1[0];
            case 2:
            {
                var n = nums1.Concat(nums2).ToArray();
                return (double)(n[0]+n[1])/2;
            }
        }


        var medI = len / 2;
  
        var nums = new int[len];
        var i = 0;
        var i1 = 0;
        var i2 = 0;

        for (i = 0; i <= medI; i++)
        {
            if (i1 < nums1.Length && i2 < nums2.Length)
            {
                if (nums1[i1] < nums2[i2])
                {
                    nums[i] = nums1[i1];
                    i1++;
                }
                else
                {
                    nums[i] = nums2[i2];
                    i2++;
                }
            }
            else
            if (i1 < nums1.Length)
            {
                nums[i] = nums1[i1];
                i1++;
            }
            else
            {
                nums[i] = nums2[i2];
                i2++;
            }

        }

        return (len % 2 == 0) ? ((double)nums[medI] + nums[medI + 1]) / 2 : nums[medI];

    }
    
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