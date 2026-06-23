//  РЕШИЛ С LLM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leetcode
{
    public sealed class IsValidBST
    {
        public bool IsValidBST(TreeNode root)
        {           
            return Validate(node, null, null);
        }

        private bool Validate(TreeNode node, long? min, long? max)
        {
            if (node is null)
            {
                return true;
            }

            if ((min != null && node.val <= min) || (max != null && node.val >= max))
            {
                return false;
            }


            return Validate(node.left, min, node.val) 
                && Validate(node.right, node.val, max);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}

public sealed class IsValidBstInOrder
{
    private long? _prevValue = null;

    public bool IsValidBST(TreeNode root)
    {
        _prevValue = null; 
        return InOrder(root);
    }

    private bool InOrder(TreeNode node)
    {
        if (node is null)
        {
            return true;
        }

        if (!InOrder(node.left))
        {
            return false;
        }

        if (_prevValue != null && node.val <= _prevValue)
        {
            return false;
        }
        
        _prevValue = node.val;

        return InOrder(node.right);
    }
}