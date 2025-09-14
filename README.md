# นาย ณัฐวุฒิ จันทร์สนิท 673450036-4
# SwordMan
## อนิเมชั่นการยืน(idle)

<img width="839" height="520" alt="image" src="https://github.com/user-attachments/assets/a7b037cd-8277-475c-98d6-a2e910e1aeda" />

โดยตรง Player_idle จะแสดงเป็นสีส้ม หมายถึงเป็น Default ของการแสดงเอนิเมชั่น เมื่อ Player อยู่กับที่ จะเล่น Player_idle ที่เป็น Default

## อนิเมชั่นเดินหน้าและกลับหลัง(Move)

<img width="713" height="503" alt="image" src="https://github.com/user-attachments/assets/5a05543b-f377-444c-8b96-a2a5ffae2c34" />

โดยเราจะเชื่อมอนิเมชั่นจาก Player_idle  มาที่ Move เพื่อเปลี่ยนการเล่นอนิเมชั่น และเมื่ออยู่เฉยๆก็จะเปลี่ยน อนิเมชั่นจาก Move กลับไปที่ Player_idle ที่เป็น Default
## การเดินหน้าและกลับหลัง

<img width="789" height="210" alt="image" src="https://github.com/user-attachments/assets/6fb4f5f6-3c09-4de1-892c-970a7864726d" />

โดยเราจะไปตั้ง Input System ที่ Actionสร้างActionใหม่ โดยกดปุ่ม + แล้วตั้งชื่อว่าPlayerจะปรากฏ Actionsใหม่ขึ้นมาที่หน้าคอลัมน์ Actions ตั้งชื่อว่า Jump

ที่ด้านล่างของ Actions กดเลือกเพื่อทำการ Binding หรือการผูกคำสั่งนี้กับปุ่มที่เราต้องการ กดเลือก  Binding Path ให้เป็น Space และ ปุ่มเครื่องหมาย ขึ้น

สร้าง Actions ใหม่ชื่อ Move กำหนด Action Type เป็น Value และ Control Type เป็น Any

- ทำการเพิ่ม Negative/Positive Binding ให้กับ  Move ตั้งชื่อว่า LeftRight
- ที่ด้านล่างของ Move จะมี Negative และ Positive ทำการ Binding คีย์ของปุ่ม โดย Negative เป็นปุ่ม `A` และ Positive เป็นปุ่ม `D`

## เขียนโค้ดสำหรับการเดินและกลับหลัง
# GatherInput.cs

<img width="552" height="730" alt="image" src="https://github.com/user-attachments/assets/b3ff0542-c406-46b6-ab2a-1d1ee6a8545c" />

ไฟล์ GatherInput.cs สร้างขึ้นมาสำหรับกำหนดการรับข้อมูลจาก Input ผู้ใช้ โดยทำการผูกเหตุการณ์ต่าง ๆ และกำหนดฟังก์ชั่นในการรับคำสั่ง

# PlayerMoveControls.cs

<img width="474" height="197" alt="image" src="https://github.com/user-attachments/assets/720a54d8-27d4-4d25-82b4-f0e87bcd29bb" />

<img width="543" height="173" alt="image" src="https://github.com/user-attachments/assets/8e2f5c4c-13e6-4930-a443-fb9bed76c8c5" />

<img width="1049" height="146" alt="image" src="https://github.com/user-attachments/assets/80fdb461-6f6e-4345-ac5f-9f8dd5a4c500" />

ไฟล์PlayerMoveControls.cs  สำหรับใช้ทำการกำหนดการเคลื่อนไหวตัวละคร โดยทำการรับค่าจากไฟล์ GatherInput.cs

# PlayerMoveControls.cs

<img width="858" height="596" alt="image" src="https://github.com/user-attachments/assets/49377abe-6373-4424-a92f-6bcd018d66e3" />

- กำหนดตัวแปรที่ชื่อ `direction` โดยเราจะกำหนดให้ค่าที่เป็น + หมายถึงตัวละครหันไปทางขวามือของเรา นั่นคือภาพปรกติของ Sprite ของตัวละคร ในทางตรงกันข้าม ถ้าค่าเป็นลบ ตัวละครก็จะหันไปทิศทางตรงกันข้าม
- สร้างฟังก์ชั่นใหม่ชื่อ `Flip()` โดยฟังก์ชั่นนี้จะมีการตรวจสอบค่าที่ได้รับจากผู้ใช้งาน รวมกับทิศทางที่เรากำหนดไว้ในตัวแปรว่ามีค่าน้อยกว่า 0 หรือเป็นลบหรือไม่ ถ้าหากเข้าเงื่อนไข ก็จะมีการเปลี่ยนค่าของวัตถุตัวละคร โดยการเปลี่ยนขนาดของตัวละครโดยใช้คำสั่ง `localScale` เปลี่ยนเฉพาะแกน X ให้มีค่าเป็นลบ ก็จะเป็นการสลับด้านของตัวละครไปอีกทิศทางหนึ่ง
- ทำการเรียกใช้ผ่านฟังก์ชั่น `Update()` จากที่เราทราบแล้วว่า ฟังก์ชั่นนี้จะมีการเรียกใช้ทุกครั้งในทุก ๆ แฟรมที่มีการสร้างขึ้นในขณะที่เกมกำลังทำงาน

เราจะปรับเปลี่ยนการทำงานของฟังก์ชั่นภายในของโปรแกรมโดยทำการสร้างฟังก์ชั่น `Move()` ขึ้นมา เพื่อให้ง่ายต่อการเรียกใช้และจัดการ

# อนิเมชั่นกระโดดและการกระโดด

เนื่องจากเรามีการสร้างการรับการเคลื่อนไหวของการกระโดดเอาไว้แล้ว ดังนั้นเราก็จะทำการเพิ่มในส่วนของโปรแกรมเพื่อรับค่าและการเปลี่ยนแปลงตัวละครเพื่อทำการกระโดด
## โค้ดสำหรับการกระโดด ที่ GatherInput.cs

<img width="597" height="739" alt="image" src="https://github.com/user-attachments/assets/ff3732ef-f6ae-4080-aecb-1ae610c996d6" />

เมื่อเราได้ฟังก์ชั่นการกำหนดสถานะของการกระโดดแล้ว เราก็จะเพิ่มคำสั่งให้ตัวละครของเราเปลี่ยนแปลงในแนวแกน Y เพื่อให้เหมือนตัวละครของเรากระโดด ที่ไฟล์ PlayMoveControl

<img width="755" height="479" alt="image" src="https://github.com/user-attachments/assets/093e223a-87f2-4384-aaa7-a3b4454accb5" />

# อนิเมชั่นการกระโดด

<img width="800" height="218" alt="image" src="https://github.com/user-attachments/assets/e2a853e3-0380-4d1c-8020-60da85a28013" />

แก้ไข Blend Tree โดยการกดดับเบิ้ลคลิ๊ก เราจะเห็นว่า Blend Tree ที่เราสร้างขึ้น จะมี Blend Type ที่หน้าต่าง Inspector มีค่าเป็น 1D หมายถึง 1 Dimension หมายเป็นการเปลี่ยนในทิศทางเดียว 

ให้เราทำการเพิ่มตัวแปรใหม่ทางด้านซ้ายมือ ที่แต่เดิมเรามีตัวแปรที่ชื่อ Speed อยู่แล้ว เราจะทำการเพิ่ม `vSpeed` เป็นชนิด float

ที่หน้าต่าง Inspector ทำการเปลี่ยน Parameter เป็นตัวแปรใหม่ vSpeed และทำการเพิ่ม motion ใหม่ด้วยคำสั่ง Add Motion field ทำการเพิ่มใหม่ทั้งหมด 3 ฟิล แล้วให้ลากไฟล Animation ที่เราสร้างขึ้นจากบนลงล่างคือ

- Jump down
- Jump peak
- Jump up


# การบาดเจ็บและตาย

<img width="384" height="282" alt="image" src="https://github.com/user-attachments/assets/eb4c22a3-f713-4cac-9b83-fd236de31df9" />

1. Player (ตัวละครหลัก)
การเตรียมวัตถุ PlayerStats

คลิกที่ตัวละครของเรา → สร้างวัตถุว่าง (Empty Object) ข้างใน ตั้งชื่อว่า PlayerStats

เพิ่ม Polygon Collider 2D ให้กับ PlayerStats แล้วแก้ Edit Collider ให้ตรงกับรูปร่างของตัวละคร

Collider นี้จะใช้สำหรับตรวจจับการโดนโจมตี แยกออกจาก Collider ที่ใช้ยืนบนพื้น

สร้าง Layer ใหม่ ชื่อ PlayerStats และเปิด Is Trigger = true

สคริปต์ PlayerStats.cs

สร้างไฟล์ PlayerStats.cs แล้วใส่ไว้ที่วัตถุ PlayerStats
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    private bool canTakeDamage = true;

    void Start()
    {
        health = maxHealth; // เริ่มต้นเลือดเต็ม
    }

    public void TakeDamage(float damage)
    {
        if(!canTakeDamage) return; // ถ้าอยู่ในช่วงกันดาเมจ ให้ข้ามไป

        health -= damage;
        if(health <= 0)
        {
            // ปิด Collider และควบคุมตัวละคร
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<GatherInput>().DisableControls();
            Debug.Log("Player is dead");
        }

        // เริ่มดีเลย์ป้องกันการโดนซ้ำทันที
        StartCoroutine(DamagePrevention());
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f); // หน่วงเวลา 0.15 วิ
        if (health > 0)
        {
            canTakeDamage = true; // ถ้ายังไม่ตาย ก็รับดาเมจใหม่ได้
        }
    }
}

maxHealth = เลือดสูงสุด

health = เลือดปัจจุบัน

TakeDamage() = หักเลือด → ถ้าเลือดหมดให้ปิดการบังคับ

ใช้ Coroutine เพื่อหน่วงเวลา ไม่ให้โดนลดเลือดหลายครั้งติดกันเร็วเกินไป

# หยุดการเคลื่อนไหวเมื่อ Player ตาย
ไปที่ไฟล์ GatherInput.cs เพิ่มฟังก์ชันนี้เพื่อยกเลิกการควบคุมทั้งหมด
public void DisableControls() 
{
    myControl.Player.Move.performed -= StartMove;
    myControl.Player.Move.canceled -= StopMove;

    myControl.Player.Jump.performed -= JumpStart;
    myControl.Player.Jump.canceled -= JumpStop;

    myControl.Player.Disable();
    valueX = 0;
}

Spike (หนามที่ทำดาเมจ)
การเตรียมวัตถุ Spike

ลาก Sprite (เช่น Sword) มาวางในฉาก แล้วเปลี่ยนชื่อเป็น Spike

เพิ่ม Rigidbody2D ตั้งค่า Body Type → Kinematic

เพิ่ม Polygon Collider 2D แล้วเปิด Is Trigger

สร้าง Layer ใหม่ ชื่อ EnemyAttack และใส่ให้กับ Spike

ไปที่ Project Settings → Physics 2D ตั้งค่าให้ PlayerStats สามารถชนกับ EnemyAttack

สคริปต์ Spikes.cs

สร้างไฟล์ Spikes.cs แล้วใส่ในวัตถุ Spike

using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStats"))
        {
            Debug.Log("Player hit by spikes");
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}

damage = ความเสียหายที่ Spike ทำได้

ใช้ OnTriggerEnter2D() ตรวจจับว่าชนกับ PlayerStats หรือไม่

ถ้าใช่ → เรียก TakeDamage() จาก PlayerStats

สรุปการทำงาน

ตัวละครมีเลือด (PlayerStats) ที่ลดลงเมื่อโดนหนาม (Spike)

ถ้าเลือดหมด → ปิดการบังคับตัวละคร + Debug ข้อความว่า "Player is dead"

ใช้ Coroutine ป้องกันการโดนดาเมจซ้ำรัว ๆ

ทุกครั้งที่ตัวละครเดินชน Spike จะเห็นเลือดลดลงใน Console
