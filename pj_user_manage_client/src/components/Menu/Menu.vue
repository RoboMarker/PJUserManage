<template>
  <el-row class="tac">
    <el-col :span="4">
      <h5 class="mb-2">選單</h5>
      <el-menu  default-active="1"  class="el-menu-vertical-demo"  @open="handleOpen"  @close="handleClose">
        <el-menu-item  v-for="(item, index) in listMenuItem" :key="item.menuId" :index="`${index + 1}`" @click="funMenuItemClick(item)">
          <el-icon class=""></el-icon>
          <span>{{item.menuName}}</span>
        </el-menu-item>
      </el-menu>
    </el-col>
  </el-row>
</template>

<script lang="ts">
import { defineComponent,reactive,ref } from 'vue';
import { ElMenu, ElMenuItem, ElMenuItemGroup, ElSubMenu, ElIcon, ElRow, ElCol } from 'element-plus';
import { default as axios } from 'axios';



export default defineComponent({
  components: {
    ElMenu,
    ElMenuItem,
    ElMenuItemGroup,
    ElSubMenu,
    ElIcon,
    ElRow,
    ElCol,
  },
  props:{
    UserId:String
  },
  setup(props) {
      let listMenuItem:any = reactive([]);
     funGetUserHaveMenu();
    function funGetUserHaveMenu()
    {
        var vUser:any=reactive({
          UserId:"MEM2022112400002"
          //UserId:props.UserId
        });

        var vUrl = "https://localhost:44346/api/Menu/GetUserHaveMenu?UserId="+vUser.UserId;
        axios({
            method: "get",
            url: vUrl,
            data:vUser,
            headers: {
                'Content-Type': 'application/json',
            }
        }
        ).then(res => {
            console.log(res);
            if(res.status==200)
            {
                console.log(res.data);
                listMenuItem.splice(0, listMenuItem.length, ...res.data);//...展開字符
            }
        }).catch(function (error) {
            console.log(error)
        });
    }

    function funMenuItemClick(item:any){
      //this.$router.push('/MenuList');
    }


    const handleOpen = (key:any, keyPath:any) => {
      console.log(key, keyPath);
    };

    const handleClose = (key:any, keyPath:any) => {
      console.log(key, keyPath);
    };

    return {
      handleOpen,
      handleClose,
      listMenuItem,
      funMenuItemClick
    };
  },
});
</script>