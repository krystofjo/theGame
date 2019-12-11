﻿using UnityEngine;


public class SingleSegmentSwitcher : AbstractSegmentSwitcher
{
    [SerializeField]
    PathSegment otherSegment;

    public override PathSegment GetNextSegment(PathSegment currentSegment, bool force = false)
    {
        return otherSegment;
    }
}