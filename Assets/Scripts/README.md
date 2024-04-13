
# はじめに：カスタムトラック共通の概念について説明

* カスタムトラック作成時には主に `TrackAsset`・`PlayableAsset`・`PlayableBehaviour`の三つのクラスを拡張して実装します。
* カスタムトラックの構成要素は主に４つです。
* ひとつめは `TrackAsset` を拡張したトラッククラスです。このカスタムトラックにおいて、バインディングオブジェクトの型やクリップクラスの型、処理の実装クラスの型を定義します。
* ふたつめは `PlayableAsset` を拡張したクリップクラスです。クリップごとのプロパティを定義し、実行時には処理の実装クラスへ値を引き継ぎます。
* みっつめは `PlayableBehaviour` を拡張した処理の実装を行う Behaviour クラスです。フレームごとにクリップ上での値が変化するという場合、このクラスで時間ごとの値を計算します。
* よっつめは `PlayableBehaviour` を拡張し Behaviour で計算した値のミキシングとバインディングオブジェクトへの反映を行う MixerBehaviour クラスです。クリップ同士が重なった場合にそれぞれの Behaviour で値を計算した結果を全て受け取って、比重に照らし合わせて合成するミキシングという処理を行います。また、このクラスではトラックに設定されたバインディングオブジェクトを取得できるので、ミキシングした値をバインディングオブジェクトへ反映させる処理も行います。


# BlendShapeの値を時間に沿って変化させるカスタムトラック

* `BlendShape` から始まるスクリプトは、BlendShapeの値を時間に沿って変化させるカスタムトラックのためのものです。
* クリップでは BlendShape の種類と、開始終了時の BlendShape の値をそれぞれ設定し、クリップの再生フレームごとに値を変化させます。
* 値の遷移パターンは5種類用意されており、`Linear`・`EaseIn`・`EaseOut`・`PingPong`・`Immediate` から選択可能です。
* クリップ終了時点で処理が実行されるかどうかが不定なので、クリップ終了の前に余裕をもって終了時の状態にするためのオフセットの期間である `finalStateLeadTime` が用意されています。
* BlendShape の値を反映させるには対象のゲームオブジェクトに `FacialController` をアタッチし、トラックのバインディングオブジェクトとして指定します。`FacialController` は VRM の 0 系の構成のオブジェクトに対して BlendShape や眼球の動きなどを制御するためのコンポーネントです。


# 眼球の回転を時間に沿って変化させるカスタムトラック

* `EyeRotation` から始まるスクリプトは、VRM の 0 系の構成のオブジェクトの眼球の回転を時間に沿って変化させるカスタムトラックのためのものです。
* クリップでは開始終了時の眼球の回転の値をそれぞれ設定し、クリップの再生フレームごとに値をリニアに変化させます。
* BlendShape の値を反映させるには対象のゲームオブジェクトに `FacialController` をアタッチし、トラックのバインディングオブジェクトとして指定します。`FacialController` は VRM の 0 系の構成のオブジェクトに対して BlendShape や眼球の動きなどを制御するためのコンポーネントです。


# オブジェクトの位置を時間に沿って変化させるカスタムトラック

* `Transform` から始まるスクリプトは、ゲームオブジェクトの Transform の値を時間に沿って変化させるカスタムトラックのためのものです。
* クリップでは開始終了時の Transform の値をそれぞれ設定し、クリップの再生フレームごとに値を変化させます。
* 値の遷移パターンは5種類用意されており、`Linear`・`EaseIn`・`EaseOut`・`PingPong`・`Immediate` から選択可能です。
* クリップ終了時点で処理が実行されるかどうかが不定なので、クリップ終了の前に余裕をもって終了時の状態にするためのオフセットの期間である `finalStateLeadTime` が用意されています。
* Transform の値を反映させるには対象のゲームオブジェクトをトラックのバインディングオブジェクトとして指定します。
* 開始終了時の Transform の値を設定する際には、`Copy Scene View Camera Transform To StartTransform` ボタン及び `Copy Scene View Camera Transform To EndTransform` ボタンを利用すると、表示しているシーンビューのカメラの位置と回転がそのまま設定されます。
