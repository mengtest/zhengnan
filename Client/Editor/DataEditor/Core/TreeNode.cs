﻿using System.Collections.Generic;

namespace DataEditor
{
    public class TreeNode
    {
	    public enum TreeNodeType
	    {
		    Item,
		    Switch
	    }

	    public string name;
	    public TreeNodeType nodeType = TreeNodeType.Item;
	    public TreeNode parent;
	    public List<TreeNode> children = null;
	    public bool isOpen = false;
	    public static TreeNode _instance = null;

	    public static TreeNode Get()
	    {
		    if (_instance == null)
		    {
			    _instance = new TreeNode();
		    }

		    return _instance;
	    }

	    public void InsertNode(TreeNode node)
	    {
		    if (this.children == null)
		    {
			    this.children = new List<TreeNode>();
		    }

		    children.Add(node);
		    node.parent = this;
	    }

	    public void OpenAllNode(TreeNode node)
	    {
		    node.isOpen = true;
		    if (node.children != null && node.children.Count > 0)
		    {
			    for (int i = 0; i < node.children.Count; i++)
			    {
				    OpenAllNode(node.children[i]);
			    }
		    }
	    }

	    public TreeNode GenerateFileTree(List<string> list)
	    {
		    TreeNode root = new TreeNode();
		    root = GenerateFileNode("", "生物/", list);
		    OpenAllNode(root);
		    return root;
	    }

	    public TreeNode GenerateFileNode(string parentFullPath, string path, List<string> list)
	    {
		    TreeNode node = new TreeNode();
		    string[] segment = path.Split('/');
		    if (segment.Length > 1)
		    {
			    string name = segment[0];
			    node.name = name;
			    node.nodeType = TreeNodeType.Switch;
			    string fullPath = parentFullPath + name + "/";
			    List<string> allChildrenPath = list.FindAll(s =>
				    {
					    if (s.StartsWith(fullPath) && s != fullPath)
					    {
						    return true;
					    }

					    return false;
				    }
			    );
			    List<string> dirList = new List<string>();
			    for (int i = 0; i < allChildrenPath.Count; i++)
			    {
				    string childPath = allChildrenPath[i].Remove(0, fullPath.Length);
				    string[] childPathSegment = childPath.Split('/');
				    if (childPathSegment.Length > 1)
				    {
					    string childDirPath = childPathSegment[0];
					    if (!dirList.Contains(childDirPath))
					    {
						    dirList.Add(childDirPath);
						    TreeNode childNode = GenerateFileNode(fullPath, childDirPath + "/", list);
						    node.InsertNode(childNode);
					    }
				    }
				    else
				    {
					    TreeNode childNode = GenerateFileNode(fullPath, childPath, list);
					    node.InsertNode(childNode);
				    }
			    }
		    }
		    else
		    {
			    node.name = path;
			    node.nodeType = TreeNodeType.Item;
			    list.Remove(path);
		    }

		    return node;
	    }
    }
}