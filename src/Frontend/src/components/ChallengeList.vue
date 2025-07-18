<script setup lang="ts">
import { onBeforeMount, reactive } from 'vue';
import type { ChallengeResponse } from '@/clients/apiClients/models';
import { createClient } from '@/services/apiClientFactory';

const challenges = reactive<ChallengeResponse[]>([]);

onBeforeMount(async () => {
  const client = createClient();
  const results = (await client.api.challenges.get()) ?? [];
  challenges.push(...results);
});
</script>

<template>
  <table>
    <thead>
      <tr>
        <th>Id</th>
        <th>Year</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="challenge in challenges" :key="challenge.id!">
        <td>{{ challenge.id }}</td>
        <td>{{ challenge.year }}</td>
      </tr>
    </tbody>
  </table>
</template>
