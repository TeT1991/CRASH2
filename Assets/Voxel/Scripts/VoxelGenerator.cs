using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;

public class VoxelGenerator : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Texture2D levelTex;
    [SerializeField] private Voxel voxelPrefab;
    [SerializeField] private float voxelSize;
    [SerializeField] private Transform voxelsParent;

    [Header(" Other ")]
    [SerializeField] private Robot robot;

    [Header(" Materials ")]
    [SerializeField] private Material baseMaterial;
    List<Material> materials = new List<Material>();

    private void Awake()
    {
        UIManager.onGameSet += UpdateVoxelColliders;
    }

    private void OnDestroy()
    {
        UIManager.onGameSet -= UpdateVoxelColliders;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Generate();
    }

    public void Generate(Texture2D tex)
    {
        levelTex = tex;
        Generate();
    }

    private void Generate()
    {
        Vector3 startPosition = voxelSize * Vector3.up + Vector3.right;
        Color voxelColor;
        Voxel voxelInstance;

        for (int x = 0; x < levelTex.width; x++)
        {
            for (int y = 0; y < levelTex.height; y++)
            {
                voxelColor = levelTex.GetPixel(x, y);
                if (voxelColor.a < .5f)
                    continue;

                voxelColor = Randomize(voxelColor);

                Vector3 spawnPosition = startPosition + voxelSize * (x * Vector3.right + y * Vector3.up);

                voxelInstance = Instantiate(voxelPrefab, spawnPosition, Quaternion.identity, voxelsParent);
                voxelInstance.Configure(voxelSize, GetMaterial(voxelColor));

                /*
                voxelInstance.transform.localScale = voxelSize * Vector3.one;
                voxelInstance.Colorize(GetMaterial(voxelColor)); 
                */         
           
            }
        }
    }

    private void UpdateVoxelColliders()
    {
        float robotLength = robot.GetMaxLength();
        float distance;

        for (int i = 0; i < voxelsParent.childCount; i++)
        {
            distance = Vector3.Distance(voxelsParent.GetChild(i).position, robot.transform.position);

            if (distance <= robotLength + 2f)
                voxelsParent.GetChild(i).GetComponent<Collider>().enabled = true;
        }
    }

    private Color Randomize(Color color)
    {
        return color;

        float h;
        float s;
        float v;

        Color.RGBToHSV(color, out h, out s, out v);

        h += Random.Range(-.03f, .03f);
        s += Random.Range(-.02f, .02f);
        v += Random.Range(-.02f, .02f);

        return Color.HSVToRGB(h, s, v);
    }

    private Material CreateNewMaterial(Color color)
    {
        Material mat = new Material(baseMaterial);
        mat.SetColor("_BaseColor", color);

        materials.Add(mat);

        return mat;//materials[materials.Count - 1];
    }

    private Material GetMaterial(Color color)
    {
        //Material material = null;

        for (int i = 0; i < materials.Count; i++)
            if (materials[i].GetColor("_BaseColor") == color)
                return materials[i];

        return CreateNewMaterial(color);
    }

}
