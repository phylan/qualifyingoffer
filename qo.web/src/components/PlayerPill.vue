<template>
        <div class="p-3">
            <div class="text-maroon uppercase tracking-wide">{{rank}}. {{ player.name }}</div>
            <div class="text-green-700" v-if="hasSalaryData">
                {{ formattedSalary }}
            </div>
            <div class="text-gray-700 italic" v-else>
                No salary data available
            </div>
        </div>
</template>

<script>
export default {
    props: {
        player: {
            type: Object
        },
        rank: {
            type: Number
        }
    },
    computed: {
        hasSalaryData() {
            return this.player.salary != null
        },
        formattedSalary() {
            if(!this.hasSalaryData) { return }
            let formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })
            return formatter.format(this.player.salary)
        },
    }
}
</script>