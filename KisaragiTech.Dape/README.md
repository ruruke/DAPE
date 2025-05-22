# KisaragiTech.Dape

DAPE へようこそ！
このプロジェクトは発展途上です。

## 必要なもの
- Neo4j v5.24
- .NET SDK v9
- ポートを開けられる環境

## 起動方法

```shell
KisaragiTech.Dape/KisaragiTech.Dape$ mkdir ../run
KisaragiTech.Dape/KisaragiTech.Dape$ "$EDITOR" ../run/config.json
KisaragiTech.Dape/KisaragiTech.Dape$ dotnet run -- --run-dir ../run
```

## コンフィグの例

Neo4jの初期ユーザーはすべての権限を持っているため、適宜権限を絞ったユーザーを作成することが**強く**推奨される。
```json
{
  "database": {
    "host": "localhost",
    "port": 12345,
    "user": "dape",
    "password": "dape-database-password"
  }
}
```

## ライセンス
決めかねている: 将来はFLOSSライセンスにする予定。

開発または動作確認のためにクローン・フォーク・ビルド・改変することは認める。
また、改変したソースコードを公開することも認めるがビルド成果物は公開してはならない。

