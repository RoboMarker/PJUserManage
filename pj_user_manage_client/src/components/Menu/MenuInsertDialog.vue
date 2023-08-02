<template>
  <div>
    <el-button type="primary" @click="showDialog">{{ buttonLabel }}</el-button>
    <el-dialog
      v-model="dialogVisible"
      :title="`${buttonLabel}`"
      @close="closeDialog"
    >
      <el-form
        ref="ruleFormRef"
        :model="ruleForm"
        :rules="rules"
        label-width="120px"
        class="demo-ruleForm"
        :size="formSize"
        status-icon
      >
        <el-form-item label="選單名稱" prop="menuName">
          <el-input v-model="ruleForm.menuName" />
        </el-form-item>
        <el-form-item label="權限類型" prop="permissionsId">
          <el-select
            v-model="ruleForm.permissionsId"
            placeholder="Activity zone"
          >
            <el-option
              v-for="item in IPermissionData"
              :label="item.permissionsName"
              :value="item.permissionsId"
            />
          </el-select>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="add(ruleFormRef)">
            Create
          </el-button>
          <el-button @click="resetForm(ruleFormRef)">Reset</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>
  </div>
</template>

<script lang="ts" setup>
import { defineProps, ref, reactive, toRefs,onMounted } from "vue";
import {
  ElButton,
  ElDialog,
  ElForm,
  ElFormItem,
  ElInput,
  ElOption,
  ElSelect,
} from "element-plus";
import type { FormInstance, FormRules } from "element-plus";

import IMenu from "../../dist/ts/interfaces/IMenu";
//import IMenu from "../../dist/ts/interfaces/IMenu";
import IPermission from "../../dist/ts/interfaces/IPermission";
import { default as axios } from "axios";


interface RuleForm {
  menuName: string;
  permissionsId: string;
  UserId: string;
}
 let IPermissionData: IPermission[] = reactive([]);

const props = defineProps({
  buttonLabel: {
    type: String,
    default: "彈出視窗",
  },
});
   
onMounted(() => {
  // 在組件初始化後執行的程式碼
  fetchData(); // 執行取得資料的函式
  });

async function fetchData() {
  // 執行非同步操作，例如發送 API 請求
var vUrl = "https://localhost:44346/api/Permissions/GetAll";
axios({
  method: "get",
  url: vUrl,
  headers: {
    "Content-Type": "application/json",
  },
})
  .then((res) => {
    console.log(res);
    if (res.status == 200) {
      const dataWithSerialNumber = res.data.map(
        (item: IMenu, index: number) => {
          return {
            ...item,
            serialNumber: index + 1, // 新增的序號欄位
          };
        }
      );

      IPermissionData.splice(
        0,
        IPermissionData.length,
        ...dataWithSerialNumber
      );
      console.log(res.data);
    }
  })
  .catch(function (error) {
    console.log(error);
  });
}


const formSize = ref("default");
//const ruleFormRef = ref<FormInstance | null>(null);
const ruleFormRef = ref<FormInstance>();
const ruleForm = reactive<RuleForm>({
  menuName: "",
  permissionsId: "",
  UserId: "",
});


const dialogVisible = ref(false);
const showDialog = () => {
  dialogVisible.value = true;
};
const closeDialog = () => {
  dialogVisible.value = false;
};
const confirmDialog = () => {
  // 在這裡執行確認按鈕的操作
  console.log("確定");
  closeDialog();
};



const rules = reactive<FormRules<RuleForm>>({
  menuName: [
    { required: true, message: "請輸入選單名稱", trigger: "blur" },
    { min: 1, max: 20, message: "請勿超過20個字", trigger: "blur" },
  ],
  permissionsId: [
    {
      required: true,
      message: "請選擇一個權限",
      trigger: "change",
    },
  ],
});

const add = async (formEl: FormInstance | undefined) => {
  var v1 = ruleFormRef;
  if (!formEl) return;

  await formEl.validate((valid, fields) => {
    if (valid) {
      let vNewUrl = "https://localhost:44346/api/Permissions/";
      axios({
        method: "post",
        url: vNewUrl,
        //data:{ruleForm,UserId:"MEM2022112400002"},
        data:{MenuName:ruleForm.menuName,PermissionsId:ruleForm.permissionsId,UserId:"MEM2022112400002"},
        //data:ruleForm,
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((res) => {
          console.log(res);
          if (res.status == 200) {
            const dataWithSerialNumber = res.data.map(
              (item: IMenu, index: number) => {
                return {
                  ...item,
                  serialNumber: index + 1, // 新增的序號欄位
                };
              }
            );
            //vMenuList.splice(0, vMenuList.length, ...dataWithSerialNumber);
            console.log(res.data);
          }
        })
        .catch(function (error) {
          console.log(error);
        });
    } else {
      console.log("error submit!", fields);
    }
  });
};

const resetForm = (formEl: FormInstance | undefined) => {
  if (!formEl) return;
  formEl.resetFields();
};

const options = Array.from({ length: 10000 }).map((_, idx) => ({
  value: `${idx + 1}`,
  label: `${idx + 1}`,
}));
</script>