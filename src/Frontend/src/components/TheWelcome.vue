<script setup lang="ts">
import WelcomeItem from './WelcomeItem.vue';
import { onBeforeMount, reactive } from 'vue';

const openReadmeInEditor = () => fetch('/__open-in-editor?file=README.md');

interface Challenge {
  id: string;
  year: number;
}

const challenges = reactive<Challenge[]>([]);

onBeforeMount(async () => {
  let res = await fetch('/api/challenges');
  let results = await res.json();

  challenges.push(...results);
});
</script>

<template>
  <WelcomeItem>
    <template #icon>🎮</template>

    <table>
      <thead>
        <tr>
          <th>Id</th>
          <th>Year</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="challenge in challenges" :key="challenge.id">
          <td>{{ challenge.id }}</td>
          <td>{{ challenge.year }}</td>
        </tr>
      </tbody>
    </table>
  </WelcomeItem>
</template>
