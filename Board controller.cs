using Godot;
using System;

public partial class BoardController : TileMapLayer
{
	TileMapLayer map;
	int lastVector = 2;
	Vector2I vector1;
	Vector2I vector2;
	Char direction1 = 'U';
	Char direction2 = 'D';
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		vector1 = new Vector2I(-1,7);
		vector2 = new Vector2I(8,0);
		map = this; 
		for( int i = 0; i < 8; i++)
			for (int j = 0; j < 8; j++)
			{
				setTile(i,j);
			}
		
	}
	
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
		{
			AddTile();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	// places proper tile color
	private void setTile( int x, int y )
	{
		if( ( x + y ) % 2 == 0)
		{
			map.SetCell(new Vector2I(x,y), 0, new Vector2I(1,0));
		}
		else
		{
			map.SetCell(new Vector2I(x,y), 0, new Vector2I(0,0));
		}
	}
	
	private void setTile( Vector2I v )
	{
		setTile(v.X, v.Y);
	}
	
	public void AddTile()
	{
		if(lastVector == 2)
		{
			lastVector = 1;
			switch(direction1)
			{
				case 'U':
					setTile(vector1);
					if( map.GetCellTileData( new Vector2I( vector1.X + 1, vector1.Y)) == null)
					{
						vector1.X += 1;
						direction1 = 'R';
					}
					else
						vector1.Y -= 1;
					break;
				case 'L':
					setTile(vector1);
					if( map.GetCellTileData( new Vector2I( vector1.X , vector1.Y - 1)) == null)
					{
						vector1.Y -= 1;
						direction1 = 'U';
					}
					else
						vector1.X -= 1;
					break;
				case 'R':
					setTile(vector1);
					if( map.GetCellTileData( new Vector2I( vector1.X , vector1.Y + 1)) == null)
					{
						vector1.Y += 1;
						direction1 = 'D';
					}
					else
						vector1.X += 1;
					break;
				case 'D':
					setTile(vector1);
					if( map.GetCellTileData( new Vector2I( vector1.X - 1, vector1.Y)) == null)
					{
						vector1.X -= 1;
						direction1 = 'L';
					}
					else
					vector1.Y += 1;
					break;
				Default:
					break;
			}
			
		}
		else
		{
			lastVector = 2;
			
			//GD.Print(map.GetCellTileData( new Vector2I( vector2.X - 1, vector2.Y)));
			switch(direction2)
			{
				case 'U':
					setTile(vector2);
					if( map.GetCellTileData( new Vector2I( vector2.X + 1, vector2.Y)) == null)
					{
						vector2.X += 1;
						direction2 = 'R';
					}
					else
						vector2.Y -= 1;
					break;
				case 'L':
					setTile(vector2);
					if( map.GetCellTileData( new Vector2I( vector2.X , vector2.Y - 1)) == null)
					{
						vector2.Y -= 1;
						direction2 = 'U';
					}
					else
						vector2.X -= 1;
					break;
				case 'R':
					setTile(vector2);
					if( map.GetCellTileData( new Vector2I( vector2.X , vector2.Y + 1)) == null)
					{
						vector2.Y += 1;
						direction2 = 'D';
					}
					else
						vector2.X += 1;
					break;
				case 'D':
					setTile(vector2);
					if( map.GetCellTileData( new Vector2I( vector2.X - 1, vector2.Y)) == null)
					{
						vector2.X -= 1;
						direction2 = 'L';
					}
					else
						vector2.Y += 1;
					break;
				Default:
					break;
			}
		}
			
	}
	
	
}
