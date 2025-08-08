<script setup lang="ts">
import { onBeforeMount, reactive, ref } from 'vue';
import type { ChallengeResponse } from '@/clients/apiClients/models';
import { createClient } from '@/services/apiClientFactory';
import type { DataTableHeader } from 'vuetify';
import router from '@/router';

const headers: DataTableHeader[] = [
  { title: 'Username', key: 'username', sortable: true },
  { title: 'Year', key: 'year', sortable: true },
];

const challenges = reactive<ChallengeResponse[]>([]);
const loading = ref(false);

onBeforeMount(async () => {
  loading.value = true;
  const client = createClient();
  const results =
    (await client.api.challenges.get({
      queryParameters: {
        g: false, // Do not include games in the response
      },
    })) ?? [];

  challenges.push(...results);

  loading.value = false;
});

const goToChallenge = (e: Event, row: any) => {
  router.push({ name: 'challenge', params: { id: row.item.shortId } });
};
</script>

<template>
  <v-data-table
    :items="challenges"
    :headers="headers"
    :loading="loading"
    no-data-text="Aucun jeu n'a été ajouté à ce challege pour le moment."
    hide-default-footer
    @click:row="goToChallenge"
  >
    <template #top>
      <v-toolbar flat>
        <v-toolbar-title>Challenges</v-toolbar-title>
      </v-toolbar>
    </template>
  </v-data-table>
</template>
