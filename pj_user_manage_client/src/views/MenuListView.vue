<template>
  <div class="home">
    <el-button type="primary" @click="funGetAllMenu()">查詢</el-button>
    <MenuInsertDialog buttonLabel="新增選單" permissionsList=""> </MenuInsertDialog>
    <Mytest buttonLabel="新增選單2"> </Mytest>
    <el-table :data="vMenuList">
      <el-table-column label="序號" prop="serialNumber" />
      <el-table-column label="選單名稱" prop="menuName" />
      <el-table-column label="是否啟用" prop="status" />
      <el-table-column label="選單類型" prop="menuType" />
      <el-table-column label="特別使用者" prop="customizedUserId" />
      <el-table-column align="right">
        <template #header>
          <el-input
            v-model="search"
            size="small"
            placeholder="Type to search"
          />
        </template>
        <template #default="scope">
          <el-button size="small" @click="handleEdit(scope.$index, scope.row)"
            >Edit</el-button
          >
          <el-button
            size="small"
            type="danger"
            @click="handleDelete(scope.$index, scope.row)"
            >Delete</el-button
          >
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, computed, reactive,onMounted } from "vue";
import { ElButton, ElInput, ElTableColumn, ElTable } from "element-plus";
import { default as axios } from "axios";
import IMenu from "../dist/ts/interfaces/IMenu";
import MenuInsertDialog from "../components/Menu/MenuInsertDialog.vue";
import Mytest from "../components/Menu/test.vue";
import IPermission from "../dist/ts/interfaces/IPermission";



export default defineComponent({
  name: "MenuListView",
  components: {
    ElButton,
    ElInput,
    ElTableColumn,
    ElTable,
    MenuInsertDialog,
    Mytest
  },
  setup(props) {
    const search = ref("");
    let vMenuList: IMenu[] = reactive([]);
    //let vMenuList = ref<IMenu[]>([]);
    let vNew: IMenu[] = reactive([]);

    async function funGetAllMenu() {
      var vUrl = "https://localhost:44346/api/Menu/GetAllMenu";
      //vUrl = "https://localhost:7084/api/WeatherForecast/Get";

      await axios({
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
            vMenuList.splice(0, vMenuList.length, ...dataWithSerialNumber);
            console.log(res.data);
          }
        })
        .catch(function (error) {
          console.log(error);
        });
    }

    const handleEdit = (index: number, row: IMenu) => {
      console.log(index, row);
    };

    const handleDelete = (index: number, row: IMenu) => {
      console.log(index, row);
    };

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

    return {
      funGetAllMenu,
      search,
      handleEdit,
      handleDelete,
      vMenuList,
      vNew,

      dialogVisible,
      showDialog,
      closeDialog,
      confirmDialog,
    };
  },
});
</script>