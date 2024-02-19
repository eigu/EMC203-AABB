public static class CollisionLibrary
{
    public static bool CheckCollision(Shape shapeA, Shape shapeB)
    {
        if (shapeA is BoxCollider && shapeB is BoxCollider)
        {
            var boxA = (BoxCollider)shapeA;
            var boxB = (BoxCollider)shapeB;

            return DidCollide(boxA, boxB);
        }

        return false;
    }

    public static bool DidCollide(BoxCollider boxA, BoxCollider boxB)
    {
        return BoxCheck(boxA.xMin, boxA.xMax, boxB.xMin, boxB.xMax)
            && BoxCheck(boxA.yMin, boxA.yMax, boxB.yMin, boxB.yMax);
    }

    private static bool BoxCheck(float minA, float maxA, float minB, float maxB)
    {
        return maxA >= minB
            && minA <= maxB;
    }
}
