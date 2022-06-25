# Loot Tables on Microservices

Simple microservice based project for implementation and simulation of rolls from loot tables.
Solution currently implements 2 different use cases loot tables can be used in.

## Rolling loot
This use case simulates rolling items from dead monster, like in MMORPG games.
API with current table configuration will generate random loot consisting of:
* 5 items of various "rarity":
  * common item with drop rate of 5
  * rare item with drop rate of 3
  * epic item with drop rate of 1
* 0, 1 or 2 cloth items with specific quantity:
  * 5 - 15 of linen cloths with drop rate of 5
  * 1 - 5 wool cloths with drop rate of 2
  * nothing with drop rate of 2
* 100 - 200 gold

## Rolling gacha
This use case simulates rolling items 10 times, like in popular mobile games. 

Each roll consists of:
* determining rarity of rolled item
* rolling item from pool of items of specific "rarity"

10th pull will always guarantee rolling item of rare or epic "rarity".

The drop rates of item "rarities" are configured as follows:
* common item: 50
* rare item: 15
* epic item: 5

Each item has a drop rate of 1.
