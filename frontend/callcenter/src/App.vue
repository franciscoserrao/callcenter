<template>
  <div class="base">
    <Table class="table-container" :agents="agents">
    </Table>
  </div>
</template>

<script>
import Table from "./components/Table.vue";

export default {
  components: {
    Table
  },
  data() {
    return {
      agents: [
        { id: 1, name: "agent 1", timestamp: '2024-04-25 08:30:00', state: 'ON_CALL', skills: ["22222222-2222-2222-2222-222222222222", "22222222-5555-2222-2222-222222222222"] },
        { id: 2, name: "agent 2", timestamp: '2024-04-25 09:15:00', state: 'AVAILABLE', skills: ["22222222-2222-2222-2222-222222222222", "22222222-5555-2222-2222-222222222222"] },
        { id: 3, name: "agent 3", timestamp: '2024-04-25 10:00:00', state: 'AVAILABLE', skills: ["22222222-1111-2222-2222-222222222222", "22222222-5555-2222-2222-222222222222"] },
        { id: 4, name: "agent 4", timestamp: '2024-04-25 11:20:00', state: 'ON_LUNCH', skills: ["22222222-3333-2222-2222-222222222222", "22222222-5555-2222-2222-222222222222"] },
        { id: 5, name: "agent 5", timestamp: '2024-04-25 12:45:00', state: 'ON_LUNCH', skills: ["22222222-6666-2222-2222-222222222222", "22222222-5555-2222-2222-222222222222"] },
      ]
    };
  }
};
</script>

<style>
.table-container {
  width: 75%;
  margin: 0 auto;
}

.base {
  width: 1200px;
}
</style>
