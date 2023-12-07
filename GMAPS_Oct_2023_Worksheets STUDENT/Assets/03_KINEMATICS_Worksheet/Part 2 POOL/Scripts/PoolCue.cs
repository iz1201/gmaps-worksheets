using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
 	public LineFactory lineFactory;
	public GameObject ballObject;

	private Line drawnLine;
	private Ball2D ball;

	private void Start()
	{
 		ball = ballObject.GetComponent<Ball2D>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //start drawing line
			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
			{
				drawnLine = lineFactory.GetLine(startLinePos, endLinePos, thicknessValue); //get line from line factory
				drawnLine.EnableDrawing(true); //enable drawing of line
			}
		}
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			drawnLine.EnableDrawing(false); //disable drawing 

			//update the velocity of the white ball.
			HVector2D v = new HVector2D(drawnLine.end.x - drawnLine.start.x, drawnLine.end.y - drawnLine.start.y); //calculates the velocity vector
			ball.Velocity = v; //set the calculated velocity vector to ball

			drawnLine = null; // End line drawing            
		}

		if (drawnLine != null)
		{
            var endLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			drawnLine.end = new Vector2(endLinePos.x, endLinePos.y); // Update line end
		}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
 	public void Clear()
	{
		var activeLines = lineFactory.GetActive();

		foreach (var line in activeLines)
		{
 		 line.gameObject.SetActive(false);
		}
	}
}
