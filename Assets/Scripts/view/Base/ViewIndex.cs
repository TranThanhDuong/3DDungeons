using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    EmptyView=0,
    PauseView,
}
public class ViewConfig 
{
    public static ViewIndex[] viewIndices = {
     ViewIndex.EmptyView,
     ViewIndex.PauseView,
     };
}
public class ViewParam
{

}
public class PauseParam: ViewParam
{
    public int totalKill;
}