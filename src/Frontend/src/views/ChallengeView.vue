<script setup lang="ts">
import type { ChallengeResponse, GameResponse } from '@/clients/apiClients/models';
import { createClient } from '@/services/apiClientFactory';
import { onMounted, ref } from 'vue';

const props = defineProps<{
  id: string;
}>();

const loading = ref(false);
const gamesLoading = ref(false);

const client = createClient();
const challenge = ref<ChallengeResponse | undefined>(undefined);
const games = ref<GameResponse[] | undefined>(undefined);

const headers = [
  { title: 'Name', key: 'name', sortable: true },
  { title: 'Year', key: 'year', sortable: true },
  { title: 'Status', key: 'status', sortable: true },
];

onMounted(async () => {
  await loadChallenge();
  loadGames();
});

const loadChallenge = async () => {
  loading.value = true;
  challenge.value = await client.api.challenges.byChallengeId(props.id).get();
  loading.value = false;
};

const loadGames = async () => {
  gamesLoading.value = true;
  games.value = await client.api.challenges.byChallengeId(props.id).games.get();
  gamesLoading.value = false;
};

const addGame = async () => {
  const newGame = await client.api.challenges.byChallengeId(props.id).games.post({
    year: 2023,
  });

  if (newGame) {
    games.value?.push(newGame);
  }
};
</script>

<template>
  <v-data-table
    v-if="!loading && challenge"
    :items="games"
    :headers="headers"
    :loading="gamesLoading"
    no-data-text="Aucun challenge n'a été créé pour le moment."
    hide-default-footer
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title> {{ challenge.username }} - {{ challenge.year }} </v-toolbar-title>

        <v-btn
          class="me-2"
          prepend-icon="mdi-plus"
          text="Add a game"
          border
          @click="addGame"
        ></v-btn>
      </v-toolbar>
    </template>
  </v-data-table>
  <div v-else-if="!loading">
    <p>CE challenge n'existe pas.</p>
  </div>
</template>
