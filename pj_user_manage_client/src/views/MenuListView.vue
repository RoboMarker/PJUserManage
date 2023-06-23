<template>
  <div class="home">
     <el-button size="small" @click="funGetAllMenu()">click</el-button>
    <el-table :data="filterTableData" >
      <el-table-column label="Date" prop="date" />
      <el-table-column label="Name" prop="name" />
      <el-table-column align="right">
        <template #header>
          <el-input v-model="search" size="small" placeholder="Type to search" />
        </template>
        <template #default="scope">
          <el-button size="small" @click="handleEdit(scope.$index, scope.row)">Edit</el-button>
          <el-button size="small" type="danger" @click="handleDelete(scope.$index, scope.row)">Delete</el-button>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
import { ElButton, ElInput,ElTableColumn,ElTable } from 'element-plus';
import { default as axios } from 'axios';

interface User {
  date: string;
  name: string;
  address: string;
}

export default defineComponent({
  name: 'MenuListView',
  components: {
    ElButton, ElInput,ElTableColumn,ElTable
  },
  setup() {
    const search = ref('');
    const tableData: User[] = [
      {
        date: '2016-05-03',
        name: 'Tom',
        address: 'No. 189, Grove St, Los Angeles',
      },
      {
        date: '2016-05-02',
        name: 'John',
        address: 'No. 189, Grove St, Los Angeles',
      },
      {
        date: '2016-05-04',
        name: 'Morgan',
        address: 'No. 189, Grove St, Los Angeles',
      },
      {
        date: '2016-05-01',
        name: 'Jessy',
        address: 'No. 189, Grove St, Los Angeles',
      },
    ];

    function funGetAllMenu()
    {
        var vUrl = "https://localhost:7026/api/Menu/GetAllMenu";
        //vUrl = "https://localhost:7084/api/WeatherForecast/Get";
       
        axios({
            method: "post",
            url: vUrl,
            headers: {
                'Content-Type': 'application/json',
            }
        }
        ).then(res => {
            console.log(res);
            if(res.status==200)
            {
                console.log(res.data);
              window.open("/");
            }
        }).catch(function (error) {
            console.log(error)
        });
    }

    const filterTableData = computed(() =>
      tableData.filter(
        (data) =>
          !search.value ||
          data.name.toLowerCase().includes(search.value.toLowerCase())
      )
    );

    const handleEdit = (index: number, row: User) => {
      console.log(index, row);
    };

    const handleDelete = (index: number, row: User) => {
      console.log(index, row);
    };

    return {
      funGetAllMenu,
      search,
      filterTableData,
      handleEdit,
      handleDelete,
    };
  },
});
</script>