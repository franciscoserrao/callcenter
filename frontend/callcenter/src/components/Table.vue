<template>
  <div class="table">
    <h1>Table</h1>
    <div>
      <div class="table-header">
        <div class="table-header-item" v-for="field in headerItems" :key="field">
          <p>{{ field.toUpperCase() }}</p>
          <template v-if="sortableFields.includes(field)">
            <button @click="sortData(field, 'asc')">ASC</button>
            <button @click="sortData(field, 'desc')">DESC</button>
          </template>
        </div>
      </div>
      <div class="table-row" v-for="agent in shallowRows" :key="agent">
        <div class="table-column-item" v-for="column in Object.values(agent)" :key="column">
          {{ column }}
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { computed, defineProps, ref } from 'vue';

const agentArray = defineProps({
  agents: {
    type: Array,
  }
});

const headerItems = computed(() => {
  return Object.keys(agentArray.agents[0] || {});
});

const sortableFields = ['timestamp', 'state'];

const sortData = (sortBy, order) => {
  shallowRows.value = shallowRows.value.sort((a, b) => {
    const valueA = a[sortBy];
    const valueB = b[sortBy];
    if (valueA === valueB) return 0;
    return order === 'asc' ? valueA.localeCompare(valueB) : valueB.localeCompare(valueA);
  });
};

const shallowRows = ref([...agentArray.agents]);
</script>

<style>
.table {
  width: 100%;
  margin-top: 20px;
}

.table-header,
.table-row {
  display: flex;
  flex-wrap: nowrap;
}

.table-header-item,
.table-column-item {
  flex: 1;
  border: solid 1px #000;
  padding: 8px 16px;
  box-sizing: border-box;
}

.table-header-item {
  background-color: rgb(49, 49, 49);
  color: #fff;
}

.table-column-item p {
  margin: 0;
}
</style>
