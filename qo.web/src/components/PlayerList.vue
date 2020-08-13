<template>
      <div class="border bg-white border-gray-800 rounded-lg px-20 mx-10 -mb-10 font-serif">
        <div class="px-10 h-56 pt-10">
          <div>
            The qualifying offer is a one-year contract, the value of which is calculated by averaging the highest {{ topQuantity }} player salaries from the prior season.
            {{ excludedPlayers.length }} players could not be considered in this calculation due to missing salary data for the previous season.
          </div>
          <div class="font-sans mt-3 divide-y divide-gray-400 overflow-y-auto h-64">
            <PlayerPill 
              v-for="(player, index) in selectedPlayers"
              :key="index"
              :rank="index + 1"
              :player="player"/>
          </div>
        </div>
      </div>
</template>

<script>
import PlayerPill from './PlayerPill'

export default {
    components: {
      PlayerPill
    },
    props: {
      includedPlayers: {
        type: Array
      },
      excludedPlayers: {
        type: Array
      },
      topQuantity: {
        type: Number
      }
    },
    data() {
      return {
        showIncluded: true,
        showExcluded: false
      }
    },
    computed: {
      selectedPlayers() {
        return [ ...(this.showIncluded ? this.includedPlayers : []), ...(this.showExcluded ? this.excludedPlayers : [])  ]
      }
    }
}
</script>