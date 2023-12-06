using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(1f, 1f);
    }

    void Translate(float x, float y)
    {
        translateMatrix.SetIdentity(); //sets translation matrix to an identity matrix.
        translateMatrix.SetTranslationMat(x, y); //configures the translation matrix to perform translation
        Transform(); //calls the function transform

        pos = translateMatrix * pos; //transforms the pos vector using translateMatrix
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D(); //creates a new matrix to move object to origin
        HMatrix2D fromOriginMatrix = new HMatrix2D(); //creates a new matrix to move object from origin to its original position
        HMatrix2D rotateMatrix = new HMatrix2D(); //creates a new matrix to rotate the object

        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y); //moves the object to the origin based on its current position pos.x and pos.y
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y); //moves the object back from the origin to its original position

        rotateMatrix.SetRotationMat(angle); //sets the rotation matrix based on an angle

        transformMatrix.SetIdentity(); //creates an identity matrix. This is to hold the final transformation

        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; //combine the matrices to form a transformation matrix. it performs in the order, move back from origin, rotate then move to origin

        Transform();    
}

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++) //loops through each vertex in the vertices array
        {
            HVector2D vert = new HVector2D(vertices[i].x,vertices[i].y); //creates a new 2D vector using x and y coordinates of the current vertex
            vert = transformMatrix * vert; //transforms current vertex by multiplying it with trnasformMatrix
            vertices[i].x = vert.x; //updates the x coordinate to the transformed x cocordinate
            vertices[i].y = vert.y; //updates the y coordinate to the transformed y coordinate
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
