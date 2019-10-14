using System;
using System.Collections.Generic;

namespace OPLoader
{
    [Flags]
    public enum OpCategory : ushort
    {
        //カテゴリ分けはswikiに準ずる
        //このenumはフラグ化されている．カテゴリとサブカテゴリを分けて定義
        //重複をチェック
        // X            X           XXXXXX      XXXXXXXX                          
        // weapon only  unit only   CATEGORY    SUBCATEGORY(0x00X0)
        // CATEGORY
        SW = 0x8000,//s級武器
        SU = 0x4000,//S級ユニット
        SOLE = 0x0100,//ソール
        BOOST = 0x0200,//追加アイテム
        FEEVER = 0x0300,//フィーバー
        SENTENCE = 0x0400,//センテンス
        EXTREME = 0x0500,//アルター・フリクト・スティグマ
        EV = 0x0600,//EV
        REVLY = 0x0700,//レヴリー
        FACTOR = 0x0800,//ファクター
        MARK = 0x8900,//マーク
        CATALYST = 0x0A00,//カタリスト
        MODULATOR = 0x0B00,//ウィンクルム・MAX・モデュレイター
        STATUS = 0x0C00,//ステータス
        DEBUF = 0x8C00,//状態異常
        RECEPTOR = 0x0D00,//レセプター
        PHRASE = 0x8E00,//フレイズ
        BUSTER = 0x8F00,//バスター
        RPANDSL = 0x9000,//リーパー・スレイヤー
        GIFT = 0x1100,//ギフト系
        GLARE = 0x1200,//グレア
        OTHER = 0x1300,//その他

        //SUBCATEGORY
        POWER = 0x0002,
    }

    public class OpData
    {
        public OpData(String name, ushort category, byte level)
        {
            Name = name;
            Category = category;
            Level = level;
        }

        public String Name { get; }

        // カテゴリが重複するものは共存不可
        public ushort Category { get; }
        public byte Level { get; }

    }


    /**　レシピのデータ **/
    public class OpRecipe
    {
        OpData[] material { get; }
        OpData result { get; }
        float prob { get; }
    }

    /** 触媒のデータ **/
    public class OpCatalyst
    {
        OpRecipe target { get; }
        float boost { get; }
    }

    public class OpUtilities
    {
        private static readonly System.Collections.Generic.List<OpData> registeredAllOps = new List<OpData>();
        private static readonly List<OpRecipe> registeredAllRecipes = new List<OpRecipe>();

        public static void RegisterOp(OpData op)
        {
            registeredAllOps.Add(op);
        }

        public static void RegisterRecipe(String material, String result, int prob)
        {
            // 素材
            var materialstrs = material.Split(',');
            var materialops = new List<OpData>(5);
            var referenceops = new List<OpData>(5);

            foreach (String str in materialstrs)
            {
                if (!str.StartsWith("%"))
                {
                    materialops.Add(SearchForMaterialStr(str));
                }
            }
        }

        public static OpData SearchForMaterialStr(String str)
        {
            return null;
        }

        public static OpData SearchForName(String name)
        {
            foreach (OpData op in registeredAllOps)
            {
                if (op.Name.Equals(name))
                {
                    return op;
                }
            }
            return null;
        }

    }
}
