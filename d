warning: in the working copy of 'ProjectSettings/EditorBuildSettings.asset', LF will be replaced by CRLF the next time Git touches it
[1mdiff --git a/Assets/Script.meta b/Assets/Script.meta[m
[1mdeleted file mode 100644[m
[1mindex f2fe382..0000000[m
[1m--- a/Assets/Script.meta[m
[1m+++ /dev/null[m
[36m@@ -1,8 +0,0 @@[m
[31m-fileFormatVersion: 2[m
[31m-guid: 354a75d88952ec740958804709033d71[m
[31m-folderAsset: yes[m
[31m-DefaultImporter:[m
[31m-  externalObjects: {}[m
[31m-  userData: [m
[31m-  assetBundleName: [m
[31m-  assetBundleVariant: [m
[1mdiff --git a/Assets/Script/PlayerMovement.cs b/Assets/Script/PlayerMovement.cs[m
[1mdeleted file mode 100644[m
[1mindex b14f36d..0000000[m
[1m--- a/Assets/Script/PlayerMovement.cs[m
[1m+++ /dev/null[m
[36m@@ -1,40 +0,0 @@[m
[31m-using System.Collections;[m
[31m-using System.Collections.Generic;[m
[31m-using UnityEngine;[m
[31m-[m
[31m-public class Movement : MonoBehaviour[m
[31m-{[m
[31m-    public float moveSpeed = 3;[m
[31m-    Rigidbody2D rb;[m
[31m-    Vector2 moveDirection;[m
[31m-    // Start is called before the first frame update[m
[31m-    void Start()[m
[31m-    {[m
[31m-        rb = GetComponent<Rigidbody2D>();[m
[31m-    }[m
[31m-[m
[31m-    // Update is called once per frame[m
[31m-    void Update()[m
[31m-    {[m
[31m-        inputManage();[m
[31m-    }[m
[31m-[m
[31m-    void FixedUpdate()[m
[31m-    {[m
[31m-        Move();[m
[31m-    }[m
[31m-    void inputManage()[m
[31m-    {[m
[31m-        float moveX = Input.GetAxisRaw("Horizontal");[m
[31m-        float moveY = Input.GetAxisRaw("Vertical");[m
[31m-        moveDirection = new Vector2(moveX, moveY).normalized;[m
[31m-    }[m
[31m-    void Move()[m
[31m-    {[m
[31m-        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);[m
[31m-    }[m
[31m-    private void OnAnimatorMove()[m
[31m-    {[m
[31m-        [m
[31m-    }[m
[31m-}[m
[1mdiff --git a/Assets/Script/PlayerMovement.cs.meta b/Assets/Script/PlayerMovement.cs.meta[m
[1mdeleted file mode 100644[m
[1mindex f1999f3..0000000[m
[1m--- a/Assets/Script/PlayerMovement.cs.meta[m
[1m+++ /dev/null[m
[36m@@ -1,11 +0,0 @@[m
[31m-fileFormatVersion: 2[m
[31m-guid: ad0993f55cb30d740b34f9fcfe589395[m
[31m-MonoImporter:[m
[31m-  externalObjects: {}[m
[31m-  serializedVersion: 2[m
[31m-  defaultReferences: [][m
[31m-  executionOrder: 0[m
[31m-  icon: {instanceID: 0}[m
[31m-  userData: [m
[31m-  assetBundleName: [m
[31m-  assetBundleVariant: [m
