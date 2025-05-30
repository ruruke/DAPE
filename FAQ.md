# FAQ

## 何をするソフトウェア？
いわゆるSNS実装のバックエンドを提供します。

## 名前の由来は？
Discrete ActivityPub Environment の頭字語です。

## DAPE って正式名称？
いいえ、コードネームです。そのため、今後変わる可能性が非常に高いです。

## ActivityPub に対応する？
2025年5月末では対応していません。また、ActivityPub自体を本体に実装すると、複雑さが増してしまうと考えているため、直接実装することも考えていません。
その代わり、 Concrnt の設計を参考にし、 DAPEの内部プロトコルとの翻訳を行うプロキシサーバーを実装に同梱するつもりです。これにより、事実上DAPEはActivityPubに対応しているソフトウェアと言えることになるでしょう。

## フロントエンドは提供しないの？
フロントエンドは各々のデザインセンスによる部分が大きいため、今のところ提供するつもりはありません。

もし提供するとしても、それはリファレンス実装としてマークされたり、あるいはDapeのリリースとは切り離されたりするプロジェクトになるでしょう。

## Misskeyとの違いは？
全くもって異なりますので、全てということになるでしょう。

しかし主要な違いを挙げるなら、大きく5つに分類できると考えます。
1. ライセンスによって許諾する範囲から正式名称の使用許諾を明示的に除外するつもりであること。\
   これにより、特定のサーバーがプライマリーサーバーであるという誤解を完全に排除することができます。
2. 開発体制が異なること。\
   DAPEは完全な個人開発によって進行している、発展途上のプロジェクトです。
3. データのフォーマットが異なること。 \
   データにはバイナリ形式のスキーマを採用し、よりコンパクトなペイロードによって送受信を試みます。また、従来のメカニズムの
4. API設計がキャッシュフレンドリーになっていること。
5. よりインクリメンタルなリリースを提供する予定であること。
