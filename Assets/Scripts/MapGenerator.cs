using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> wallTiles;
    public List<GameObject> deskTiles;
    public List<GameObject> genericTiles;
    public GameObject LiftRight;
    public GameObject LiftLeft;
    public GameObject playerSpawn;
    public GameObject player;
    public List<Color> couleurEtage;
    public List<Color> couleurRoofs;
    public List<GameObject> taskableDesk;
    public List<GameObject> taskableWall;
    public GameObject pnj;
    

    int largeur = 7;
    public int etage = 3;

    float largeurTile = 19.2f;
    float hauteurTile = 17.5f;

    
    int i, j;
    int rndGen;
    float rnd;
    int tileAmount = 0;
 
    List<Vector3> coord = new List<Vector3>();
    GameObject playerSpawner;
    GameObject[] walls;
    GameObject[] roofs;
    GameObject[] liftlabels;
    GameObject[] wallspawns;
    GameObject[] deskspawns;
    GameObject recup;

    void Start()
    {
        tileAmount = etage * largeur;
        //balancedGrid();
        for(i=0;i<etage;i++)
        {
            recup = Instantiate(LiftLeft, new Vector3(0, i * hauteurTile,0), Quaternion.identity);
            coord.Add(recup.GetComponent<Transform>().position);
            tileAmount--;
        }
        for (i = 0; i < etage; i++)
        {
            recup = Instantiate(LiftRight, new Vector3((largeur-1) * largeurTile, i * hauteurTile,0), Quaternion.identity);
            coord.Add(recup.GetComponent<Transform>().position);
            tileAmount--;
        }
        recup = Instantiate(playerSpawn, new Vector3(3 * largeurTile, 0, 0), Quaternion.identity);
        coord.Add(recup.GetComponent<Transform>().position);
        tileAmount--;

        for (i=0;i<taskableDesk.Count;i++)
        {
            recup = Instantiate(deskTiles[Random.Range(0, deskTiles.Count)], openSpace(), Quaternion.identity);
            //Instantiate(taskableDesk[i], FindChildWithTag(recup, "WallSpawner").GetComponent<Transform>().position, Quaternion.identity);
            tileAmount--;
        }
        for (i = 0; i < taskableWall.Count; i++)
        {
            recup = Instantiate(wallTiles[Random.Range(0, wallTiles.Count)], openSpace(), Quaternion.identity);
            //Instantiate(taskableWall[i], FindChildWithTag(recup, "WallSpawner").GetComponent<Transform>().position, Quaternion.identity);
            tileAmount--;
        }
        while(tileAmount>0)
        {
            recup = Instantiate(genericTiles[Random.Range(0, genericTiles.Count)], openSpace(), Quaternion.identity);
            tileAmount--;
        }

        damidotage();
        wallTaskablePlacement();
        deskTaskablePlacement();
        playerSpawner = GameObject.FindWithTag("PlayerSpawner");
        player.GetComponent<Transform>().position = playerSpawner.transform.position;

        GameObject BorneR, BorneL;
        for (i = 0; i < etage; i++)
        {
            for(j = 0 ; j <= i ; j++)
            {
                recup = Instantiate(pnj, new Vector3(Random.Range(2 * largeurTile, 5 * largeurTile), player.GetComponent<Transform>().position.y + (i * hauteurTile), 0), Quaternion.identity);
                BorneL = FindChildWithTag(recup, "BorneLeft");
                BorneR = FindChildWithTag(recup, "BorneRight");

                BorneL.GetComponent<Transform>().position = new Vector3(Random.Range(1 * largeurTile, recup.GetComponent<Transform>().position.x - largeurTile), BorneL.GetComponent<Transform>().position.y, 0);
                BorneR.GetComponent<Transform>().position = new Vector3(Random.Range(recup.GetComponent<Transform>().position.x + largeurTile, 6 * largeurTile), BorneL.GetComponent<Transform>().position.y, 0);
            }
        }

    }
    GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }
    Vector3 openSpace()
    {
        while(true)
        {
            Vector3 check = new Vector3(Random.Range(1, (largeur - 1)) * largeurTile, Random.Range(0, etage)* hauteurTile, 0);
            if(!coord.Contains(check))
            {
                coord.Add(check);
                return check;
            }
        }     
    }
    void randomDesk()
    {
        rndGen = Random.Range(0,deskTiles.Count);
        Instantiate(deskTiles[rndGen], new Vector3(j * largeurTile, i * hauteurTile, 0), Quaternion.identity);
    }
    void randomWall()
    {
        rndGen = Random.Range(0, wallTiles.Count);
        Instantiate(wallTiles[rndGen], new Vector3(j * largeurTile, i * hauteurTile, 0), Quaternion.identity);
    }

    void damidotage()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
        for (i = 0; i < etage; i++)
        {
            foreach (GameObject wall in walls)
            {
                if(wall.GetComponent<Transform>().position.y > (i+1)*hauteurTile)
                    wall.GetComponent<SpriteRenderer>().color = couleurEtage[i];
            }
        }

        roofs = GameObject.FindGameObjectsWithTag("Roof");
        for (i = 0; i < etage; i++)
        {
            foreach (GameObject roof in roofs)
            {
                if (roof.GetComponent<Transform>().position.y > (i + 1) * hauteurTile)
                    roof.GetComponent<SpriteRenderer>().color = couleurRoofs[i];
            }
        }

        liftlabels = GameObject.FindGameObjectsWithTag("FloorLabel");
        for (i = 0; i < etage; i++)
        {
            foreach (GameObject liftlabel in liftlabels)
            {
                if (liftlabel.GetComponent<Transform>().position.y > i * hauteurTile)
                    liftlabel.GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            }
        }
    }

    void deskTaskablePlacement()
    {
        deskspawns = GameObject.FindGameObjectsWithTag("DeskSpawner");
        List<GameObject> recup = new List<GameObject>();
        recup.AddRange(deskspawns);

        int compteur = 0, rand = 0;

        for (compteur = 0; compteur < taskableDesk.Count; compteur++)
        {
            rand = Random.Range(0, recup.Count);

            Instantiate(taskableDesk[compteur], recup[rand].transform.position, Quaternion.identity);

            recup.RemoveAt(rand); 
        }
    }
    void wallTaskablePlacement()
    {
        wallspawns = GameObject.FindGameObjectsWithTag("WallSpawner");
        List<GameObject> recup = new List<GameObject>();
        recup.AddRange(wallspawns);

        int compteur = 0, rand = 0;

        for (compteur = 0; compteur < taskableWall.Count; compteur++)
        {
            rand = Random.Range(0, recup.Count);

            Instantiate(taskableWall[compteur], recup[rand].transform.position, Quaternion.identity);

            recup.RemoveAt(rand);
        }
    }

    public float getHauteurTile()
    {
        return hauteurTile;
    }
    public float getLargeurTile()
    {
        return largeurTile;
    }

    /*void balancedGrid()
    {

        bool unbalanced = true;

        do
        {
            int deskAmount = 0;
            int wallAmount = 0;

            for (i = 0; i < etage; i++)
            {
                for (j = 0; j < largeur; j++)
                {
                    List<int> recup = new List<int>();
                    switch (j)
                    {
                        case 0:
                            recup.Add(0);
                            break;
                        case 3:
                            if (i == 0)
                                recup.Add(2);
                            else
                            {
                                recup.Add(Random.Range(3, 5));
                                if (recup[j] == 3)
                                    deskAmount++;
                                else if (recup[j] == 4)
                                    wallAmount++;
                                else
                                {
                                    recup.Add(0);
                                    Debug.Log("Probleme de génération de nombre aleatoire pour la pré-grille de nombre!");
                                }
                            }

                            break;
                        case 6:
                            tableau[i][j] = 1;
                            break;
                        default:
                            recup.Add(Random.Range(3, 5));
                            if (recup[j] == 3)
                                deskAmount++;
                            else if (recup[j] == 4)
                                wallAmount++;
                            else
                            {
                                recup.Add(0);
                                Debug.Log("Probleme de génération de nombre aleatoire pour la pré-grille de nombre!");
                            }
                            break;

                    }
                    tableau.Add(recup);
                }
            }
            if (wallAmount >= taskableWall.Count && deskAmount >= taskableDesk.Count)
            {
                unbalanced = false;
            }
            else
            {
                tableau.Clear();
            }
        } while (unbalanced);
    }*/
}
