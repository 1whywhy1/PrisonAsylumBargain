﻿/// <summary>
/// The type of item.
/// </summary>
public enum ItemType
{
	Unassigned,
	Food,
	Meds,
	Parts,
	Rags
};

public enum PlayerInControl
{
	Ava,
	Hazmat,
	Rox,
	Tempest
};

public enum TradeProgress
{
	Init,
	PlayerTurn,
	NPCTurn,
	MakeTrade
};

// TODO: Make a method that actually used this enum instead of hard coded integer values
/// <summary>
/// For trade schematic reference
/// </summary>
public enum TradeType
{
	Unassigned,
	MedsForFood,
	MedsForParts,
	MedsForRags,
	FoodForParts,
	FoodForRags,
	RagsForParts,
	FoodForMeds,
	PartsForMeds,
	RagsForMeds,
	PartsForFood,
	RagsForFood,
	PartsForRags
};
