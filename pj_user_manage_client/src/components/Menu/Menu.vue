<template>
  <el-row class="tac">
    <el-col :span="4">
      <h5 class="mb-2">Default colors</h5>
      <el-menu
        default-active="2"
        class="el-menu-vertical-demo"
        @open="handleOpen"
        @close="handleClose"
      >
        <el-sub-menu index="1">
          <template #title>
            <el-icon class="el-icon-location"></el-icon>
            <span>Navigator One</span>
          </template>
          <el-menu-item-group title="Group One">
            <el-menu-item index="1-1">item one</el-menu-item>
            <el-menu-item index="1-2">item two</el-menu-item>
          </el-menu-item-group>
          <el-menu-item-group title="Group Two">
            <el-menu-item index="1-3">item three</el-menu-item>
          </el-menu-item-group>
          <el-sub-menu index="1-4">
            <template #title>item four</template>
            <el-menu-item index="1-4-1">item one</el-menu-item>
          </el-sub-menu>
        </el-sub-menu>
        <el-menu-item index="2">
          <el-icon class="el-icon-menu"></el-icon>
          <span>Navigator Two</span>
        </el-menu-item>
        <el-menu-item index="3" disabled>
          <el-icon class="el-icon-document"></el-icon>
          <span>Navigator Three</span>
        </el-menu-item>
        <el-menu-item index="4">
          <el-icon class="el-icon-setting"></el-icon>
          <span>Navigator Four</span>
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
     funGetUserHaveMenu();
    function funGetUserHaveMenu()
    {
        var vUser:any=reactive({
          UserId:"MEM2022112400002"
          //UserId:props.UserId
        });

        var vUrl = "https://localhost:44346/api/Menu/GetUserHaveMenu?UserId="+vUser.UserId;
        //vUrl = "https://localhost:7084/api/WeatherForecast/Get";
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
            }
        }).catch(function (error) {
            console.log(error)
        });
    }


    const handleOpen = (key, keyPath) => {
      console.log(key, keyPath);
    };

    const handleClose = (key, keyPath) => {
      console.log(key, keyPath);
    };

    return {
      handleOpen,
      handleClose,
    };
  },
});
</script>